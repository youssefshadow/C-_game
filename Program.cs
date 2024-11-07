namespace IPI_FootHeritage_2024_2025
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player olive = new Player("Olive");
            Midfielder marc = new Midfielder("Marc");
            Defender bruce = new Defender("Bruce");
            Forward benjamin = new Forward("Benjamin");
            Goalkeeper tom = new Goalkeeper("Tom");

            olive.Pass(marc, new List<Player>(){ bruce });

            marc.Shoot(new List<Player>() { bruce }, tom);

            benjamin.Dribble(bruce);
            benjamin.Dribble(olive);
        }
    }
}