using System;
using System.Collections.Generic;
using System.IO;

namespace FalloutShelterEditor
{
    public class Weapon
    {
        public string Id { get; set; }
        public string Name { get; set; }

        // Override ToString for ComboBox display
        public override string ToString()
        {
            return Name;
        }
    }

    public static class Weapons
    {
        public static List<Weapon> LoadWeaponsFromCsv(string filePath)
        {
            var weapons = new List<Weapon>();

            using (var reader = new StreamReader(filePath))
            {
                bool isFirstRow = true;

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    // Skip the header row
                    if (isFirstRow)
                    {
                        isFirstRow = false;
                        continue;
                    }

                    if (values.Length > 1)
                    {
                        weapons.Add(new Weapon
                        {
                            Id = values[0],   // Assuming the "id" column is the first column (index 0)
                            Name = values[1]  // Assuming the "name" column is the second column (index 1)
                        });
                    }
                }
            }

            return weapons;
        }
    }
}
