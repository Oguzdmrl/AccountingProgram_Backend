using AccountingSolutions.Domain.Abstractions;

namespace AccountingSolutions.Domain.CompanyEntities
{
    public sealed class UniformChartOfAccount : Entity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}