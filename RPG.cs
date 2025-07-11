namespace ConsoleRPG
{
    class RPG
    {
        static void Main(string[] args)
        {
            
            Console.Write("플레이어 이름을 입력하세요: ");
            string playerName = Console.ReadLine();

            Character player = new Character
            {
                Name = playerName,
                Level = 1,
                Job = "전사",    // 필요에 따라 변경 가능
                Attack = 15,      // 기본 공격력
                Defense = 8,       // 기본 방어력
                HP = 100,     // 기본 체력
                Gold = 50       // 기본 골드
            };

            player.Inventory = new List<string>();

            
            while (true)
            {
                ShowIntro();
                Console.Write("원하시는 행동을 입력해주세요: ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int cmd) || cmd < 1 || cmd > 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("1 ~ 3 이외 입력 시 - 잘못된 입력입니다.");
                    Console.ResetColor();
                    Pause();
                    continue;
                }

                switch (cmd)
                {
                    case 1:
                        ShowStatus(player);
                        break;
                    case 2:
                        ShowInventory(player);
                        break;
                    case 3:
                        EnterShop(player);
                        break;
                }
            }
        }

        static void ShowIntro()
        {
            Console.Clear();
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine();
        }

        static void ShowStatus(Character p)
        {
            Console.Clear();
            Console.WriteLine("=== 상태 보기 ===");
            Console.WriteLine($"레벨    : {p.Level}");
            Console.WriteLine($"이름    : {p.Name}");
            Console.WriteLine($"직업    : {p.Job}");
            Console.WriteLine($"공격력  : {p.Attack}");
            Console.WriteLine($"방어력  : {p.Defense}");
            Console.WriteLine($"체력    : {p.HP}");
            Console.WriteLine($"Gold    : {p.Gold}");
            Pause();
        }

        static void ShowInventory(Character p)
        {
            Console.Clear();
            Console.WriteLine("=== 인벤토리 ===");
            if (p.Inventory.Count == 0)
            {
                Console.WriteLine("인벤토리가 비어 있습니다.");
            }
            else
            {
                for (int i = 0; i < p.Inventory.Count; i++)
                    Console.WriteLine($"{i + 1}. {p.Inventory[i]}");
            }
            Pause();
        }

        static void EnterShop(Character p)
        {
            Console.Clear();
            Console.WriteLine("=== 상점 ===");
            Console.WriteLine("1. 회복 물약 (10 Gold)");
            Console.WriteLine("2. 낡은 검 (30 Gold)");
            Console.WriteLine("3. 뒤로 가기");
            Console.Write("구매할 번호를 입력하세요: ");
            string sel = Console.ReadLine();

            if (!int.TryParse(sel, out int choice))
            {
                Console.WriteLine("잘못된 입력입니다.");
                Pause();
                return;
            }

            switch (choice)
            {
                case 1:
                    if (p.Gold >= 10)
                    {
                        p.Gold -= 10;
                        p.Inventory.Add("회복 물약");
                        Console.WriteLine("회복 물약을 구입했습니다.");
                    }
                    else Console.WriteLine("골드가 부족합니다.");
                    break;
                case 2:
                    if (p.Gold >= 30)
                    {
                        p.Gold -= 30;
                        p.Inventory.Add("낡은 검");
                        Console.WriteLine("낡은 검을 구입했습니다.");
                        
                        p.Attack += 5;
                        Console.WriteLine("공격력이 5 증가했습니다.");
                    }
                    else Console.WriteLine("골드가 부족합니다.");
                    break;
                case 3:
                    return;
                default:
                    Console.WriteLine("잘못된 선택입니다.");
                    break;
            }

            Pause();
        }

        static void Pause()
        {
            Console.WriteLine();
            Console.Write("계속하려면 아무 키나 누르세요...");
            Console.ReadKey();
        }
    }

    class Character
    {
        public int Level { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int HP { get; set; }
        public int Gold { get; set; }
        public List<string> Inventory { get; set; }
    }
}
