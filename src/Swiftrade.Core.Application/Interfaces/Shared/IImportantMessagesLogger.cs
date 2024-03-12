namespace Swiftrade.Core.Application.Interfaces.Shared;

public interface IImportantMessagesLogger
{
    string PostMessage(string text, string channel = null);
}