// создали поток
Stream stream =  new MemoryStream(4);
//записали в поток массив байт
stream.Write(new byte[] { 1, 2, 3, 4 });
byte[] mass = new byte[4]; 
stream.Position = 0;
//в mass с 0 позиции записали 4 символа
stream.Read(mass,0,4);

foreach(byte b in mass)
{
    Console.WriteLine(b);
}

//работа с двоичными данными
Stream stream2 = new MemoryStream(4);

BinaryWriter binaryWriter = new BinaryWriter(stream2);
//запишем число 32
binaryWriter.Write(32);
stream2.Position = 0;
BinaryReader binaryReader = new BinaryReader(stream2);
//выведем число 32
Console.WriteLine(binaryReader.ReadInt32());

//работа с файлами(записали в новый файл массив)
Stream stream3 = File.Create("file");
stream3.Write(new byte[] { 1, 2, 3, 4 });
stream3.Dispose();
Stream stream4 = File.OpenRead("file");
byte[] mass4 = new byte[4];
stream4.Read(mass4);
foreach (byte b in mass4)
{
    Console.WriteLine(b);
}

Stream stream5 = File.Create("file.txt");
TextWriter textWriter = new StreamWriter(stream5);
textWriter.Write(32);
textWriter.Flush();
stream5.Dispose();

using (Stream stream6 = File.Create("file.txt")) 
{
    using(TextWriter textWriter6 = new StreamWriter(stream6))
    {
        textWriter6.Write(64);
    }
}