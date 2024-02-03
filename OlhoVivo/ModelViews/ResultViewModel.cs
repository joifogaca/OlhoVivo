namespace OlhoVivo.ModelViews
{
    public class ResultViewModel<T>
    {
        public ResultViewModel(T data)
        {
            Data = data;
        }

        public ResultViewModel(string error)
        {
            Errors.Add(error);
        }
        public ResultViewModel(T data, List<string> errors) {
        Data = data;
        }

        public T Data { get; private set; }

        public List<string> Errors { get; private set; } = new();
    }
}
