using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web.Script.Serialization;

namespace FalloutShelterEditor
{
    internal class Vault
    {
        private Dictionary<string, object> vault;

        private const string Passphrase = "UGxheWVy";
        private const string Seed = "tu89geji340t89u2";

        private static string Decrypt(string data)
        {
            try
            {
                var bytes = Encoding.ASCII.GetBytes(Seed);
                var buffer = Convert.FromBase64String(data);
                var rgbKey = new Rfc2898DeriveBytes(Passphrase, bytes).GetBytes(0x20);
                var transform = new RijndaelManaged { Mode = CipherMode.CBC }.CreateDecryptor(rgbKey, bytes);
                var stream = new MemoryStream(buffer);
                var stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Read);
                var buffer4 = new byte[buffer.Length];
                var count = stream2.Read(buffer4, 0, buffer4.Length);
                stream.Close();
                stream2.Close();
                return Encoding.UTF8.GetString(buffer4, 0, count);
            }
            catch (Exception x)
            {
                Debug.WriteLine(x.GetType() + "@Vault.Decrypt(" + data.Length + "): " + x.Message);
                return null;
            }
        }

        private static string Encrypt(string data)
        {
            try
            {
                var bytes = Encoding.UTF8.GetBytes(Seed);
                var buffer = Encoding.UTF8.GetBytes(data);
                var rgbKey = new Rfc2898DeriveBytes(Passphrase, bytes).GetBytes(0x20);
                var transform = new RijndaelManaged { Mode = CipherMode.CBC }.CreateEncryptor(rgbKey, bytes);
                var stream = new MemoryStream();
                var stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Write);
                stream2.Write(buffer, 0, buffer.Length);
                stream2.FlushFinalBlock();
                var inArray = stream.ToArray();
                stream.Close();
                stream2.Close();
                return Convert.ToBase64String(inArray);
            }
            catch (Exception x)
            {
                Debug.WriteLine(x.GetType() + "@Vault.Encrypt(" + data.Length + "): " + x.Message);
                return null;
            }
        }

        public Vault()
        {
            vault = null;
        }

        public bool IsEmpty()
        {
            return vault == null || vault.Count == 0;
        }

        public bool Read(string path)
        {
            try
            {
                var content = File.ReadAllText(path);
                var buffer = Encoding.ASCII.GetBytes(content);
                var encoded = new UTF8Encoding().GetString(buffer);
                var data = Decrypt(encoded);
                vault = new JavaScriptSerializer().Deserialize<Dictionary<string, object>>(data);
                return true;
            }
            catch (Exception x)
            {
                Debug.WriteLine(x.GetType() + "@Vault.Read(" + path + "): " + x.Message);
                return false;
            }
        }

        public bool Write(string path, string backupOld = null)
        {
            try
            {
                if (backupOld != null)
                {
                    var backupPath = path + backupOld;
                    if (File.Exists(backupPath))
                    {
                        File.Delete(backupPath);
                    }
                    File.Move(path, backupPath);
                }

                var content = new JavaScriptSerializer().Serialize(vault);
                var data = Encrypt(content);
                var encoded = new UTF8Encoding().GetBytes(data);
                var buffer = Encoding.ASCII.GetString(encoded);
                File.WriteAllText(path, buffer);
                return true;
            }
            catch (Exception x)
            {
                Debug.WriteLine(x.GetType() + "@Vault.Write(" + vault.Count + ", " + path + "): " + x.Message);
                return false;
            }
        }

        public object Get(params string[] path)
        {
            return SubGet(vault, path);
        }

        private static object SubGet(object node, params string[] path)
        {
            // Gets a single Value at the end of a path, starting at a node
            //Console.WriteLine("Vault.SubGet(" + string.Join("»", path) + ")");

            if (path == null || path.Length == 0)
            {
                return node;
            }

            // Get the First element of the Path
            var head = (string)path.GetValue(0);

            // Get every element except for the first
            var tail = new string[path.Length - 1];
            Array.Copy(path, 1, tail, 0, tail.Length);

            // Get the Type of node
            var type = node.GetType();
            if (type == typeof(Dictionary<string, object>))
            {
                // If the node is a Dictionary, cast it to one
                var tree = (Dictionary<string, object>)node;

                foreach (var branch in tree.Keys)
                {
                    // Follow every branch
                    if (branch.Equals(head))
                    {
                        // If it's what we're looking for (head)
                        return tail.Length == 0 ? tree[branch] : SubGet(tree[branch], tail);
                    }
                }
            }
            else if (type == typeof(ArrayList))
            {
                // When the node is an Array, cast it to one
                var array = (ArrayList)node;

                // Check if the head is an index and convert it
                var index = 0;
                var valid = int.TryParse(head, out index);

                if (valid)
                {
                    // If the head is an Integer, follow that index
                    return tail.Length == 0 ? array[index] : SubGet(array[index], tail);
                }
                // If we didn't get an integer return the array
                return array;
            }
            else
            {
                // Return what we have
                Debug.WriteLine("@Vault.SubGet(" + string.Join("»", path) + "): Unexpected type (" + type + ").");
                return node;
            }

            return null;
        }

        public int CountList(params string[] path)
        {
            return SubCount(vault, null, path);
        }

        public int Count(object value, params string[] path)
        {
            return SubCount(vault, value, path);
        }

        private static int SubCount(object node, object value, params string[] path)
        {
            // Gets a single Value at the end of a path, starting at a node
            //Console.WriteLine("Vault.SubCount(" + string.Join("»", path) + ")");

            var count = 0;

            // Get the First element of the Path
            var head = (string)path.GetValue(0);

            // Get every element except for the first
            var tail = new string[path.Length - 1];
            Array.Copy(path, 1, tail, 0, tail.Length);

            // Get the Type of node
            var type = node.GetType();
            if (type == typeof(Dictionary<string, object>))
            {
                // When the node is a Dictionary, cast it to one
                var tree = (Dictionary<string, object>)node;

                foreach (var branch in tree.Keys)
                {
                    // Follow every branch
                    if (!branch.Equals(head)) continue;
                    // If it's what we're looking for (head)
                    if (tail.Length == 0)
                    {
                        // If the path is over, check if this element equals the value
                        if (value == null)
                        {
                            var leaf = tree[branch];
                            if (leaf.GetType() == typeof(Dictionary<string, object>))
                            {
                                count += ((Dictionary<string, object>)leaf).Count;
                            }
                            else if (leaf.GetType() == typeof(ArrayList))
                            {
                                count += ((ArrayList)leaf).Count;
                            }
                            else
                            {
                                count += 1;
                            }
                        }
                        else if (tree[branch].Equals(value))
                        {
                            count += 1;
                        }
                    }
                    else
                    {
                        // Keep following the path (tail)
                        count += SubCount(tree[branch], value, tail);
                    }
                }
            }
            else if (type == typeof(ArrayList))
            {
                // When the node is an Array, cast it to one
                var array = (ArrayList)node;

                // Check if the head is an index and convert it
                var index = 0;
                var valid = int.TryParse(head, out index);

                if (valid)
                {
                    // If the head is an Integer
                    if (tail.Length == 0)
                    {
                        // If the path is over, ignore
                        if (value == null)
                        {
                            // If we have no Value to match with, count everything
                            count += array.Count;
                        }
                        else
                        {
                            Debug.WriteLine("@Vault.SubCount(" + string.Join("»", path) + "): Unexpected value (" + type +
                                            ").");
                            return 0;
                        }
                    }
                    else
                    {
                        // Keep following the path (tail)
                        count += SubCount(array[index], value, tail);
                    }
                }
                else
                {
                    // If we didn't get an integer count each element in the array
                    foreach (var element in array)
                    {
                        count += SubCount(element, value, path);
                    }
                }
            }
            else
            {
                // Count as a single element
                count += 1;
            }

            return count;
        }

        public bool Set(object value, params string[] path)
        {
            return SubSet(vault, value, path);
        }

        private static bool SubSet(object node, object value, params string[] path)
        {
            // Sets the Value at the end of a path, starting at a node
            Console.WriteLine("SubSet(" + value + ", " + string.Join("»", path) + ")");

            if (path == null || path.Length == 0)
            {
                node = value;
                return true;
            }

            // Get the First element of the Path
            var head = (string)path.GetValue(0);

            // Get every element except for the first
            var tail = new string[path.Length - 1];
            Array.Copy(path, 1, tail, 0, tail.Length);

            // Get the Type of node
            var type = node.GetType();
            if (type == typeof(Dictionary<string, object>))
            {
                // When the node is a Dictionary, cast it to one
                var tree = (Dictionary<string, object>)node;

                foreach (var branch in tree.Keys)
                {
                    // Follow every branch
                    if (!branch.Equals(head)) continue;
                    // If it's what we're looking for (head)
                    if (tail.Length != 0) return SubSet(tree[branch], value, tail);
                    // Set the Value
                    tree[branch] = value;
                    return true;
                    // Keep following the path (tail)
                }
            }
            else if (type == typeof(ArrayList))
            {
                // When the node is an Array, cast it to one
                var array = (ArrayList)node;

                // Check if the head is an index and convert it
                var index = 0;
                var valid = int.TryParse(head, out index);

                if (valid)
                {
                    // If the head is an Integer
                    if (tail.Length == 0)
                    {
                        // If the path is over, Set its Value
                        array[index] = value;
                        return true;
                    }
                    // Keep following the path (tail)
                    return SubSet(array[index], value, tail);
                }
                // If we didn't get an index, just carry on for all elements
                if (tail.Length == 0)
                {
                    // Follow each path and retain head in case of gateway arrays
                    var validArray = true;
                    foreach (var element in array)
                    {
                        if (SubSet(element, value, path) == false)
                        {
                            validArray = false;
                        }
                    }
                    return validArray;
                }
                else
                {
                    // Keep following the path from every branch (tail), maintain the path
                    var validArray = true;
                    foreach (var element in array)
                    {
                        if (SubSet(element, value, path) == false)
                        {
                            validArray = false;
                        }
                    }
                    return validArray;
                }
            }
            else
            {
                // Return false
                Debug.WriteLine("@Vault.SubSet(" + value + ", " + string.Join("»", path) +
                                "): Unable to follow this path.");
                return false;
            }

            return false;
        }

        private static string ExportNode(object node, int indent = 0)
        {
            var output = string.Empty;

            if (node == null)
            {
                return output;
            }

            var type = node.GetType();
            if (type == typeof(Dictionary<string, object>))
            {
                var data = (Dictionary<string, object>)node;

                if (data.Keys.Count == 0)
                {
                    return "{}";
                }

                output += "{\n";

                foreach (var item in data)
                {
                    output += StringHelper.GetIndent(indent + 1);
                    output += item.Key;
                    if (item.Value != null)
                    {
                        output += ": ";
                        output += ExportNode(item.Value, indent + 1);
                        output += ",\n";
                    }
                    else
                    {
                        output += ": null\n";
                    }
                }

                output += StringHelper.GetIndent(indent) + "}";
            }
            else if (type == typeof(ArrayList))
            {
                var array = (ArrayList)node;

                if (array.Count == 0)
                {
                    return "[]";
                }

                output += "[";

                for (var i = 0; i < array.Count; ++i)
                {
                    output += ExportNode(array[i], indent);
                    if (i < array.Count - 1)
                    {
                        output += ",";
                    }
                }

                output += "]";
            }
            else
            {
                output += node.ToString();
            }

            return output;
        }

        public bool Export(string path)
        {
            try
            {
                File.WriteAllText(path, ExportNode(vault));
                return true;
            }
            catch (Exception x)
            {
                Debug.WriteLine(x.GetType() + "@Vault.Export(" + path + "): " + x.Message);
                return false;
            }
        }
    }
}