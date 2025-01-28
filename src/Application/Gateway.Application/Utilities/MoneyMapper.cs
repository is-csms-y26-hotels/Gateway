namespace Gateway.Application.Utilities;

public static class MoneyMapper
{
    public static Google.Type.Money MapMoneyType(decimal money)
    {
        var mappedMoney = new Google.Type.Money
        {
            DecimalValue = money,
        };

        return mappedMoney;
    }
}