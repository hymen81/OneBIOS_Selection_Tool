using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OneBIOS_SKUID_Selection
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        const int QUEST_SIZE = 11;
        int QuestionScore;
        List<Question> questions = new List<Question>();
        List<string> ansLabels;
        Stack<int> undoStack = new Stack<int>();
        List<List<Selection>> buttonsLabels;
        public MainWindow()
        {
            InitializeComponent();

            buttonsLabels = StringData.getButtonData;
            ansLabels = StringData.getAnsData;

            List<string> questionLabels = StringData.getQuestionData;
      
            for (int i = 0; i < QUEST_SIZE; i++)      
                questions.Add(new Question(i, questionLabels[i], buttonsLabels[i]));
           
            this.QuestionScore = 0;
            this.QLabel.Content = questions[this.QuestionScore].QString;
            this.LButton.Content = questions[this.QuestionScore].ButtonsLabel[(int)BUTTON_POSIOION.left].Label;
            this.RButton.Content = questions[this.QuestionScore].ButtonsLabel[(int)BUTTON_POSIOION.right].Label;
            this.MButton.Content = questions[this.QuestionScore].ButtonsLabel[(int)BUTTON_POSIOION.mid].Label;
            this.MButton.Visibility = Visibility.Visible;
            this.UndoButton.IsEnabled = false;
        }

        private void ButtonCheck(BUTTON_POSIOION pos, string ansString)
        {
            if (BUTTON_POSIOION.undo == pos)
            {
                if (undoStack.Count > 0)
                {
                    this.QuestionScore -= undoStack.Pop();//回歸問題tree的位置
                    for (int i = 0; i < 2; i++)//把Q跟A移除掉
                        this.QuestionHistroyList.Items.RemoveAt(this.QuestionHistroyList.Items.Count - 1);
                    this.UndoButton.IsEnabled = undoStack.Count > 0;//防呆 stack的size要大於0才能點
                }            
            }
            else//點下左邊中間右邊的button之後
            {
                int score = questions[this.QuestionScore].ButtonsLabel[(int)pos].JumpStep;            
                if (-1 == score)//代表到了結尾
                {
                    MessageBox.Show(ansLabels[questions[this.QuestionScore].ButtonsLabel[(int)pos].AnsID], "Infromation");
                    return;
                }
                undoStack.Push(score);//執行過的放到stack做紀錄
                this.QuestionHistroyList.Items.Add(this.QLabel.Content);//印出問題
                this.QuestionHistroyList.Items.Add("A:" + ansString);
                this.UndoButton.IsEnabled = true;
                this.QuestionScore += score;
            }
            this.LButton.Content = questions[this.QuestionScore].ButtonsLabel[(int)BUTTON_POSIOION.left].Label;
            this.RButton.Content = questions[this.QuestionScore].ButtonsLabel[(int)BUTTON_POSIOION.right].Label;

            if (questions[this.QuestionScore].ButtonsLabel.Count > 2) 
            {
                this.MButton.Content = questions[this.QuestionScore].ButtonsLabel[(int)BUTTON_POSIOION.mid].Label;
                this.MButton.Visibility = Visibility.Visible;
            }
            else
                this.MButton.Visibility = Visibility.Hidden;
            this.QLabel.Content = questions[this.QuestionScore].QString;
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ButtonCheck(StringData.ButtonType[((Button)sender).Name], ((Button)sender).Content.ToString());
        }
    }

    public class Selection
    {
        public Selection(string label, int jumpStep, int ansID)
        {
            this.label = label;
            this.jumpStep = jumpStep;
            this.ansID = ansID;
        }
        public string Label { get { return this.label; } }
        public int JumpStep { get { return this.jumpStep; } }
        public int AnsID { get { return this.ansID; } }

        private string label;
        private int jumpStep;
        private int ansID;
    }


    public class Question
    {
        public Question(int id, string qString, List<Selection> buttonsLabel)
        {
            this.id = id;
            this.qString = qString;
            this.buttonsLabel = buttonsLabel;
        }
        public int ID { get { return this.id; } }
        public string QString { get { return this.qString; } }
        public List<Selection> ButtonsLabel { get { return this.buttonsLabel; } }

        private int id;
        private string qString;
        private List<Selection> buttonsLabel;
    }
    public enum BUTTON_POSIOION
    {
        left,
        right,
        mid,
        undo
    }
}
