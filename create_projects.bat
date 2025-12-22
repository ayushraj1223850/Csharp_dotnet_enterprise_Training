cd Loops
for %%f in (17_FibonacciSeries 18_PrimeNumber 19_ArmstrongNumber 20_ReverseAndPalindrome 21_GCD_LCM 22_PascalsTriangle 23_BinaryToDecimal 24_DiamondPattern 25_FactorialLarge 26_GuessingGame 27_DigitalRoot 28_ContinueUsage 29_MenuSystem 30_StrongNumber 31_SearchWithGoto) do (
  mkdir %%f
  cd %%f
  dotnet new console
  cd ..
)
