using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FalloutShelterEditor
{
    public class Pet
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public string Bonus { get; set; }

        public string bonusValue { get; set; }

        // Override ToString for ComboBox display
        public override string ToString()
        {
            return Name;
        }
    }

    public static class Pets
    {
        public static List<Pet> LoadPetsFromCsv(string filePath)
        {
            var pets = new List<Pet>();

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
                        pets.Add(new Pet
                        {
                            Id = values[0],   // Assuming the "id" column is the first column (index 0)
                            Name = values[1],  // Assuming the "name" column is the second column (index 1)
                            Bonus = values[5],
                            bonusValue = values[6]
                        });
                    }
                }
            }

            return pets;
        }
    }
}
