int playerHealth, playerDamage, playerChakra, bossHealth, bossDamage;
int cooldown = 1, ramen = 3;
string useSkill;
string[] skills = { "kageBunshin - теневое клонирование, создаёте 10 своих коппий и атакуете врага, нанося урон в 10 раз больше",
                    "rasengan - в течении битвы накапливается чакра, когда количество чакры будет равно 8, вы сможеет использовать эту технику, урон техники - 500 ",
                    "oiroke - техника соблазнения, вы соблазняете врага, враг получит 150 урона от потери крови, способность может нанести урон только 1 раз",
                    "haremu - гарем, вы используете тенхнику \"Теневого клонирование\" и технику \"Cоблазнение\" нанося врагу 350 урона (Можно использовать после применения техники соблазнения)",
                    "ramen - велика сила рамена исцеляет вам 300 здоровлья (Всего можно использовать 3 рамена)"
};


Random rand = new Random();
playerHealth = rand.Next(200, 1300);
bossHealth = rand.Next(700, 2300);
playerDamage = rand.Next(30, 40);
bossDamage = rand.Next(110, 230);
playerChakra = 0;

Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine("Для использования техники, напиште её номер \n");
Console.ResetColor();
while (true)
{
    Console.ForegroundColor = ConsoleColor.DarkRed;
    Console.WriteLine("Здоровье босса - " + bossHealth);
    Console.WriteLine("Урон босса - " + bossDamage);
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Ваше здоровье - " + playerHealth);
    Console.WriteLine("Ваш урон - " + playerDamage);
    Console.WriteLine("Ваш запас чакры - " + playerChakra);
    Console.WriteLine("Cписок ваших способностей: ");
    Console.ForegroundColor = ConsoleColor.DarkGray;
    for (int i = 0; i < skills.Length; i++)
    {
        Console.Write($"\n{i + 1}:{skills[i]} ");
    }
    Console.ResetColor();

    ChoiseSkill:
    Console.Write("\nВыберите технику для аттаки: ");
    useSkill = Console.ReadLine();   
    switch (useSkill)
    {
        case "1":
            Console.WriteLine("Вы использовали технику теневого клонирования и нанесли босу " + playerDamage * 10 + " урона");
            bossHealth -= playerDamage * 10;
            playerChakra++;
            break;
        case "2":
            if (playerChakra < 8)
            {
                Console.WriteLine("У вас недостаточно чакры!");
            }
            else
            {
                Console.WriteLine("Вы использовали технику расенган клонирования и нанесли босу 500 урона");
                bossHealth -= 500;
                playerChakra -= 8;
                playerChakra++;
            }
            break;
        case "3":
            if (cooldown > 0)
            {
                Console.WriteLine("Вы использовали технику соблазнения и нанесли босу 150 урона");
                bossHealth -= 150;
                cooldown -= 1;
                playerChakra++;
            }
            else
            {
                Console.WriteLine("Вы больше не можете использовать эту технику");
            }
            break;
        case "4":
            if (cooldown == 0)
            {
                Console.WriteLine("Вы использовали технику гарема и нанесли босу 350 урона");
                bossHealth -= 350;
                playerChakra++;
            }
            else
            {
                Console.WriteLine("Cначала используйте технику соблазнения");
                goto ChoiseSkill;
            }
            break;
        case "5":
            if (playerHealth >= playerHealth)
            {
                Console.WriteLine("У вас максимальный уровень здоровья");
            }
            else
            {
                Console.WriteLine("Вы съели рамен, и пополнили 300хп");
                playerHealth += 300;
            }
            break;
        default:
            Console.WriteLine("Вы не можете использовать эту технику");
            break;
    }
    Console.WriteLine("Босс вас аттаковал и нанёс " + bossDamage + " урона");
    playerHealth -= bossDamage;
}