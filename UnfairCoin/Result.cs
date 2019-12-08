namespace UnfairCoin
{
    public class Result
    {
        public bool BothLoose => FirstLooseStep.HasValue && SecondLooseStep.HasValue;
        public int? FirstLooseStep { get; set; }
        public int? SecondLooseStep { get; set; }

        public override string ToString()
        {
            return $"both loose : {BothLoose} first loose {FirstLooseStep} second {SecondLooseStep}";
        }
    }
}