
DELETE FROM [Tasks];
DELETE FROM [Projects];
INSERT INTO [Projects] ([Name], [Description], [ClientName], [Budget], [Status], [TeamSize], [TechnologyStack], [CreatedAt], [Deadline])
VALUES 
('Desktop app', 'Desktop app name', 'Sample company 1', 150000.00, 1, 5, 'ASP.NET Core, React, MS SQL', DATEADD(day, -45, GETDATE()), DATEADD(month, 2, GETDATE())),
('Android app', 'Android app name', 'Sample company 2', 250000.00, 0, 3, 'Swift, UIKit, CoreData', DATEADD(day, -30, GETDATE()), DATEADD(month, 3, GETDATE())),
('IOS App', 'Ios App name', 'Sample company 3', 300000.00, 2, 8, 'Java Spring, Angular, PostgreSQL', DATEADD(day, -90, GETDATE()), DATEADD(month, 1, GETDATE())),
('CRM', 'CRM name', 'Subcontract', 180000.00, 1, 6, 'PHP Laravel, Vue.js, MySQL', DATEADD(day, -60, GETDATE()), DATEADD(month, 2, GETDATE())),
('SDK', 'SDK name', 'Subcontract', 400000.00, 0, 10, 'Python Django, React, MongoDB', DATEADD(day, -120, GETDATE()), DATEADD(month, 4, GETDATE())),
('Integration', 'Integration Name', 'Subcontract', 120000.00, 1, 4, 'C#, WCF, MS SQL', DATEADD(day, -15, GETDATE()), DATEADD(day, 45, GETDATE()));

GO

