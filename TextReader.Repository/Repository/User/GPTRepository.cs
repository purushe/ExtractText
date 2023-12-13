using OpenAI_API.Completions;
using OpenAI_API;
using TextReader.Repository.IRepository.User;

namespace TextReader.Repository.Repository.User
{
  public class GPTRepository : IGPTRepository
  {

    public string GetAnswer(string prompt)
    {
      try
      {
        string apiKey = "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";
        string answer = string.Empty;
        var openai = new OpenAIAPI(apiKey);
        CompletionRequest completion = new CompletionRequest();
        completion.Prompt = prompt;
        completion.Model = OpenAI_API.Models.Model.DavinciText;
        completion.MaxTokens = 4000;
        var result = openai.Completions.CreateCompletionAsync(completion);

        if (result != null)
        {
          foreach (var item in result.Result.Completions)
          {
            answer = item.Text;
          }
        }

        return answer;
      }
      catch
      {
        throw;
      }

    }
  }
}


