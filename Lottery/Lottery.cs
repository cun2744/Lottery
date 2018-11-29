using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery
{
    public class Lottery
    {
        private int turn;   //회차 번호
        private int first_win;
        private int second_win;
        private int third_win;
        private int fourth_win;
        private int fifth_win;
        private int sixth_win;
        private int bonus;

        public Lottery(int turn, int first_win, int second_win, int third_win, int fourth_win, int fifth_win, int sixth_win, int bonus)
        {
            this.turn = turn;
            this.first_win = first_win;
            this.second_win = second_win;
            this.third_win = third_win;
            this.fourth_win = fourth_win;
            this.fifth_win = fifth_win;
            this.sixth_win = sixth_win;
            this.bonus = bonus;
        }
        public Lottery()
        {

        }
        public int Turn { get => turn; set => turn = value; }
        public int First_win { get => first_win; set => first_win = value; }
        public int Second_win { get => second_win; set => second_win = value; }
        public int Third_win { get => third_win; set => third_win = value; }
        public int Fourth_win { get => fourth_win; set => fourth_win = value; }
        public int Fifth_win { get => fifth_win; set => fifth_win = value; }
        public int Sixth_win { get => sixth_win; set => sixth_win = value; }
        public int Bonus { get => bonus; set => bonus = value; }


    }
}
