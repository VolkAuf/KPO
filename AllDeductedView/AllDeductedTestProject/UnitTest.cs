namespace AllDeductedTestProject;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    #region Student

    [Test]
    public void ReadStudent()
    {
        var storage = new StudentStorage();
        var log = new StudentLogic(storage);
        var idModel = new StudentBindingModel() {Id = 1};
        var values = log.Read(idModel).FirstOrDefault();
        Assert.IsTrue(storage.GetElement(idModel).Equals(values));
    }

    [Test]
    public void CreateStudent()
    {
        var storage = new StudentStorage();
        var logic = new StudentLogic(storage);
        var model = new StudentBindingModel()
        {
            FirstName = "test",
            LastName = "test",
            Patronymic = "test",
            ProviderId = 2,
        };

        logic.CreateOrUpdate(model);
        var element = storage.GetFullList().LastOrDefault();
        Assert.IsTrue(element?.FirstName == model.FirstName);
    }

    #endregion

    #region Discipline

    [Test]
    public void ReadDiscipline()
    {
        var storage = new DisciplineStorage();
        var logic = new DisciplineLogic(storage);
        var idModel = new DisciplineBindingModel() {Id = 1};
        var values = logic.Read(idModel).FirstOrDefault();
        Assert.IsTrue(storage.GetElement(idModel).Equals(values));
    }

    [Test]
    public void CreateDisciplineTest()
    {
        var storage = new DisciplineStorage();
        var logic = new DisciplineLogic(storage);
        var model = new DisciplineBindingModel()
        {
            Name = "test",
            HoursCount = 9999,
            ProviderId = 2,
        };

        logic.CreateOrUpdate(model);
        var element = storage.GetFullList().LastOrDefault();
        Assert.IsTrue(element?.Name == model.Name);
    }

    #endregion

    #region Order

    [Test]
    public void ReadOrder()
    {
        var storage = new OrderStorage();
        var logic = new OrderLogic(storage);
        var idModel = new OrderBindingModel() {Id = 1};
        var values = logic.Read(idModel).FirstOrDefault();
        Assert.IsTrue(storage.GetElement(idModel).Equals(values));
    }

    [Test]
    public void CreateOrderTest()
    {
        var storage = new OrderStorage();
        var logic = new OrderLogic(storage);
        var model = new OrderBindingModel()
        {
            DateCreate = DateTime.Now,
            ProviderId = 2,
        };

        logic.CreateOrUpdate(model);
        var element = storage.GetFullList().LastOrDefault();
        Assert.IsTrue(element?.DateCreate.Date == model.DateCreate.Date);
    }

    #endregion

    #region StudyingStatus

    [Test]
    public void ReadStudyingStatus()
    {
        var storage = new StudyingStatusStorage();
        var logic = new StudyingStatusLogic(storage);
        var idModel = new StudyingStatusBindingModel() {Id = 1};
        var values = logic.Read(idModel).FirstOrDefault();
        Assert.IsTrue(storage.GetElement(idModel).Equals(values));
    }

    [Test]
    public void CreateStudyingStatusTest()
    {
        var storage = new StudyingStatusStorage();
        var logic = new StudyingStatusLogic(storage);
        var model = new StudyingStatusBindingModel()
        {
            StudentId = 4,
            StudyingBase = StudyingBase.Коммерческая,
            Course = 3,
            StudyingForm = StudyingForm.Заочная,
            DateCreate = DateTime.Now,
            ProviderId = 2,
        };

        logic.CreateOrUpdate(model);
        var element = storage.GetFullList().LastOrDefault();
        Assert.IsTrue(element?.DateCreate.Date == model.DateCreate.Date);
    }

    #endregion

    #region Group

    [Test]
    public void ReadGroup()
    {
        var storage = new GroupStorage();
        var logic = new GroupLogic(storage);
        var idModel = new GroupBindingModel() {Id = 2};
        var values = logic.Read(idModel).FirstOrDefault();
        Assert.IsTrue(storage.GetElement(idModel)?.Equals(values));
    }

    [Test]
    public void CreateGroupTest()
    {
        var storage = new GroupStorage();
        var logic = new GroupLogic(storage);
        var model = new GroupBindingModel()
        {
            Name = "test",
            CuratorName = "test",
            ProviderId = 2,
        };

        logic.CreateOrUpdate(model);
        var element = storage.GetFullList().LastOrDefault();
        Assert.IsTrue(element?.Name == model.Name);
    }

    #endregion
}