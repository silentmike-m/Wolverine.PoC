namespace Wolverine.PoC.Application.Commons;

public static class CancellationTokenFactory
{
    private const int DEFAULT_TIMEOUT_IN_SECONDS = 2;

    public static CancellationToken CreateToken(int? timeoutInSeconds = null)
    {
        var source = new CancellationTokenSource();

        timeoutInSeconds ??= DEFAULT_TIMEOUT_IN_SECONDS;

        source.CancelAfter(TimeSpan.FromSeconds(timeoutInSeconds.Value));

        return source.Token;
    }
}
