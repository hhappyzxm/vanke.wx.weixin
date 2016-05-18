--Init Admin
INSERT Users(LoginName, Password, Type) VALUES('admin', 'YWRtaW4=', 0)
INSERT Admins(RealName, UserID, Status, CreatedOn, CreatedBy) Values('系统管理员', (SELECT @@IDENTITY), 0, getdate(), 1)

-- Test Data
INSERT Users(LoginName, Password, Type) VALUES('lxl', 'bHhs', 1)
INSERT Staffs(RealName, UserID, Status, CreatedOn, CreatedBy) VALUES('刘小龙', (SELECT @@IDENTITY), 0, GETDATE(), 1)

INSERT Users(LoginName, Password, Type) VALUES('lh', 'bGg=', 1)
INSERT Staffs(RealName, UserID, Status, CreatedOn, CreatedBy) VALUES('李虎', (SELECT @@IDENTITY), 0, GETDATE(), 1)

INSERT Users(LoginName, Password, Type) VALUES('zxm', 'enht', 1)
INSERT Staffs(RealName, UserID, Status, CreatedOn, CreatedBy) VALUES('赵旭明', (SELECT @@IDENTITY), 0, GETDATE(), 1)

INSERT Items(Name, Status, CreatedOn, CreatedBy) VALUES('会务电脑', 0, GETDATE(), 1)
INSERT Items(Name, Status, CreatedOn, CreatedBy) VALUES('单反相机', 0, GETDATE(), 1)
INSERT Items(Name, Status, CreatedOn, CreatedBy) VALUES('投影仪', 0, GETDATE(), 1)
INSERT Items(Name, Status, CreatedOn, CreatedBy) VALUES('插座', 0, GETDATE(), 1)