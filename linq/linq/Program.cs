string[] people = { "Tom", "Bob", "Sam", "Tim", "Tomas" };
var selectedPeople = people.Where(p => p.ToUpper().StartsWith("T")).OrderBy(p => p);
foreach (var person in selectedPeople)
{
    Console.WriteLine(person);
}
void SimpleC()
{
    string[]people = { "Tom", "Bob", "Sam", "Tim", "Tomas" };
    var selectedPeople = new List<string>();

    foreach (var person in people)
    {
    if (person.ToUpper().StartsWith('T'))
        { selectedPeople.Add(person); }
    }
    selectedPeople.Sort();

    foreach (var person in selectedPeople)
        Console.WriteLine(person);
}
