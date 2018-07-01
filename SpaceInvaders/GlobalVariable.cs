/*
 The GlobalVariable class is a static class that hold a few global common field, properties and methods.
 */
using System.Drawing;
using System.Media;

namespace SpaceInvaders
{
    public static class GlobalVariable
    {
        private const int NIMAGES = 0b101;

        public static Bitmap bitmapMotherShip = new Bitmap(Properties.Resources.MotherShip,0b1100100,0b110001);
        public static Bitmap bitmapEnemyShip = new Bitmap(Properties.Resources.EnemyShip,0b100011,0b100011);
        public static Bitmap bitmapMissle = new Bitmap(Properties.Resources.Missle,0b1111,0b101010);
        public static Bitmap bitmapBomb = new Bitmap(Properties.Resources.Bomb,0b1010,0b11001);
        public static int Half = 0b10;
        private static bool soundSwitch = true; //the switch of sound effect

        //declear SoundPlayer list
        public static SoundPlayer tr_holo_congrats = new SoundPlayer(Properties.Resources.tr_holo_congrats);
        public static SoundPlayer ctwin = new SoundPlayer(Properties.Resources.ctwin);
        public static SoundPlayer tu_spindown = new SoundPlayer(Properties.Resources.shoot);
        public static SoundPlayer letsgo = new SoundPlayer(Properties.Resources.letsgo);
        public static SoundPlayer tutor_msg = new SoundPlayer(Properties.Resources.tutor_msg);
        public static SoundPlayer explode4 = new SoundPlayer(Properties.Resources.explode4);
        public static SoundPlayer game_music = new SoundPlayer(Properties.Resources.game_music);

        /// <summary>
        /// Play Sound
        /// </summary>
        /// <param name="sp">SoundPlayer object</param>
        public static void PlaySound(SoundPlayer sp)
        {
            if (GlobalVariable.SoundSwitch)
            {
                using (sp)
                {
                    sp.Play();
                }
            }
        }

        public static Image[] GetExplosionImages()
        {
            Image[] images = new Image[NIMAGES];
            for (int i = 0; i < images.Length; i++)
            {
                images[i] = (Bitmap)Properties.Resources.ResourceManager.GetObject("E" + i.ToString());
            }
            return images;
        }

        public static Size boundries { get; set; }
        public static bool SoundSwitch { get => soundSwitch; set => soundSwitch = value; }
    }
}
