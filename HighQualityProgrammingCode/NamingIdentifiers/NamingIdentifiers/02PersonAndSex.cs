namespace NamingIdentifiers
{
    class PersonAndSex
    {
        enum Sex
        {
            Male,
            Female
        };

        class Person
        {
            public Sex Sex { get; set; }

            public string  PersonName { get; set; }

            public int Age { get; set; }
        }

        public void CreatePerson(int magicPersonNumber)
        {
            Person newPerson = new Person();
            newPerson.Age = magicPersonNumber;
            if (magicPersonNumber % 2 == 0)
            {
                newPerson.PersonName = "The muscle";
                newPerson.Sex = Sex.Male;
            }
            else
            {
                newPerson.PersonName = "The chick";
                newPerson.Sex = Sex.Female;
            }
        }
    }
}