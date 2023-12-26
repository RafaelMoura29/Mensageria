namespace EasyNetQ.Console
{
    public class Person
    {
        public Person(string fullName, string document, DateTime birthDate)
        {
            FullName = fullName;
            Document = document;
            BirthDate = birthDate;
        }

        public string FullName { get; }
        public string Document { get; }
        public DateTime BirthDate { get; }
    }
}
