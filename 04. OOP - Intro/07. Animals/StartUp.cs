using System;

namespace _07._Animals
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string inputGender;
            string details;

            try
            {

                while ((inputGender = Console.ReadLine()) != "Beast!")
                {
                   string[] detailsGender = Console.ReadLine().Split();
                   
                    switch(inputGender)
                    {
                        case "Cat":
                            string currentName = detailsGender[0];
                            int currentAge = int.Parse(detailsGender[1]);
                            string currentGender = detailsGender[2];
                            Cat newCat = new Cat(currentName, currentAge, currentGender);
                            newCat.ProduceSound();
                            break;
                        case "Dog":
                            currentName = detailsGender[0];
                            currentAge = int.Parse(detailsGender[1]);
                            currentGender = detailsGender[2];
                            Dog newDog = new Dog(currentName, currentAge, currentGender);
                            newDog.ProduceSound();
                            break;
                        case "Frog":
                            currentName = detailsGender[0];
                            currentAge = int.Parse(detailsGender[1]);
                            currentGender = detailsGender[2];
                            Frog newFrog = new Frog(currentName, currentAge, currentGender);
                            newFrog.ProduceSound();
                            break;
                        case "Kitten":
                            currentName = detailsGender[0];
                            currentAge = int.Parse(detailsGender[1]);
                            currentGender = detailsGender[2];
                            Cat newKitty = new Cat(currentName, currentAge, currentGender);
                            newKitty.ProduceSound();
                            break;
                        case "Tomcat":
                            currentName = detailsGender[0];
                            currentAge = int.Parse(detailsGender[1]);
                            currentGender = detailsGender[2];
                            Cat newTomcatty = new Cat(currentName, currentAge, currentGender);
                            newTomcatty.ProduceSound();
                            break;
                    }
                }
            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
