--11
CREATE FUNCTION udf_GetVolunteersCountFromADepartment(@VolunteersDepartment VARCHAR(30))
RETURNS INT
AS
BEGIN

DECLARE @res INT;
SET @res = (SELECT COUNT(*) FROM Volunteers AS [v]
		JOIN VolunteersDepartments AS [vd] ON [v].DepartmentId = [vd].Id
		WHERE [vd].DepartmentName = @VolunteersDepartment);

RETURN @res;
END

SELECT [dbo].[udf_GetVolunteersCountFromADepartment] ('Education program assistant')
SELECT [dbo].[udf_GetVolunteersCountFromADepartment] ('Guest engagement')
SELECT [dbo].[udf_GetVolunteersCountFromADepartment] ('Zoo events')

CREATE PROCEDURE usp_AnimalsWithOwnersOrNot(@AnimalName VARCHAR(30))
AS
BEGIN
SELECT [a].[Name] AS [Name], ISNULL([o].[Name], 'For adoption') AS OwnersName FROM Animals AS [a]
LEFT JOIN Owners AS [o] ON [a].OwnerId = [o].Id
WHERE [a].[Name] = @AnimalName
END

EXEC usp_AnimalsWithOwnersOrNot 'Pumpkinseed Sunfish'
EXEC usp_AnimalsWithOwnersOrNot 'Hippo'
EXEC usp_AnimalsWithOwnersOrNot 'Brown bear'