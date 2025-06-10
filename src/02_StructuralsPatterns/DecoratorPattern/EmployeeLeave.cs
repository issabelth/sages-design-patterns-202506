namespace DecoratorPattern;



// Urlop pracowniczy
public class EmployeeLeave
{
    public int BaseLeaveDays { get; private set; }
    public int SeniorityYears { get; private set; }
    public bool HasCompletedTraining { get; private set; }
    public bool HasSpecialBenefits { get; private set; }

    public EmployeeLeave(int baseLeaveDays, int seniorityYears, bool hasCompletedTraining, bool hasSpecialBenefits)
    {
        BaseLeaveDays = baseLeaveDays;
        SeniorityYears = seniorityYears;
        HasCompletedTraining = hasCompletedTraining;
        HasSpecialBenefits = hasSpecialBenefits;
    }

    // Oblicza ilość dni urlopu
    public int CalculateLeaveDays()
    {
        int totalLeaveDays = BaseLeaveDays;

        // Dodanie dni za staż pracy
        if (SeniorityYears >= 5)
        {
            totalLeaveDays += 5;
        }

        // Dodanie dni za ukończone szkolenia
        if (HasCompletedTraining)
        {
            totalLeaveDays += 3;
        }

        // Dodanie dni za specjalne świadczenia
        if (HasSpecialBenefits)
        {
            totalLeaveDays += 2;
        }

        return totalLeaveDays;
    }

}
