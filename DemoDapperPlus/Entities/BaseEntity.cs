namespace DemoDapperPlus.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; }
    public BaseEntity()
    {
        Id = Guid.NewGuid();
    }
}

//CREATE TABLE "Products" (
//    "Id" UUID PRIMARY KEY DEFAULT gen_random_uuid(),
//    "Name" TEXT NOT NULL,
//    "Price" NUMERIC(18,2) NOT NULL
//);
