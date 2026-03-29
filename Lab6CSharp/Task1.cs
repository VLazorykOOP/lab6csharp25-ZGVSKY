using System;

namespace Lab6
{
    public class Task1
    {
        public static void Execute()
        {
            ITrial[] trials = new ITrial[]
            {
                new Test("Math", 45),
                new Exam("Physics", "Dr. Smith"),
                new FinalExam("CS", "Prof. Johnson", 90),
                new Test("History", 30)
            };

            Array.Sort(trials);

            Console.WriteLine("--- Sorted Trials & Type Identification ---");
            foreach (var trial in trials)
            {
                trial.Show();

                if (trial is FinalExam)
                {
                    Console.WriteLine(" -> Identified using 'is': This is a Final Exam.");
                }

                Exam? examObj = trial as Exam;
                if (examObj != null)
                {
                    Console.WriteLine($" -> Identified using 'as': Handled by {examObj.Examiner}");
                }

                Console.WriteLine($" -> Exact Type using 'typeof/GetType': {trial.GetType().Name}\n");
            }
        }
    }

    public interface ITrial : IComparable<ITrial>
    {
        string Subject { get; set; }
        void Show();
    }

    public abstract class Trial : ITrial
    {
        public string Subject { get; set; }

        public Trial(string subject)
        {
            Subject = subject;
        }

        public abstract void Show();

        public int CompareTo(ITrial? other)
        {
            if (other == null) return 1;
            return string.Compare(this.Subject, other.Subject, StringComparison.Ordinal);
        }
    }

    public class Test : Trial
    {
        public int QuestionsCount { get; set; }

        public Test(string subject, int questionsCount) : base(subject)
        {
            QuestionsCount = questionsCount;
        }

        public override void Show() => Console.WriteLine($"[Test] Subject: {Subject}, Questions: {QuestionsCount}");
    }

    public class Exam : Trial
    {
        public string Examiner { get; set; }

        public Exam(string subject, string examiner) : base(subject)
        {
            Examiner = examiner;
        }

        public override void Show() => Console.WriteLine($"[Exam] Subject: {Subject}, Examiner: {Examiner}");
    }

    public class FinalExam : Exam
    {
        public int MinPassingScore { get; set; }

        public FinalExam(string subject, string examiner, int minPassingScore) : base(subject, examiner)
        {
            MinPassingScore = minPassingScore;
        }

        public override void Show() => Console.WriteLine($"[FinalExam] Subject: {Subject}, Examiner: {Examiner}, Min Score: {MinPassingScore}");
    }
}