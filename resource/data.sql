--Init Admin
INSERT Users(LoginName, Password) VALUES('admin', 'YWRtaW4=')
INSERT Admins(RealName, UserID, Status, CreatedOn, CreatedBy) Values('系统管理员', (SELECT @@IDENTITY), 0, getdate(), 1)

-- Test Data
INSERT Users(LoginName, Password) VALUES('lxl', 'bHhs')
INSERT Staffs(RealName, UserID, Status, CreatedOn, CreatedBy) VALUES('刘小龙', (SELECT @@IDENTITY), 0, GETDATE(), 1)

INSERT Users(LoginName, Password) VALUES('lh', 'bGg=')
INSERT Staffs(RealName, UserID, Status, CreatedOn, CreatedBy) VALUES('李虎', (SELECT @@IDENTITY), 0, GETDATE(), 1)

INSERT Users(LoginName, Password) VALUES('zxm', 'enht')
INSERT Staffs(RealName, UserID, Status, CreatedOn, CreatedBy) VALUES('赵旭明', (SELECT @@IDENTITY), 0, GETDATE(), 1)

INSERT Items(Name, Status, CreatedOn, CreatedBy) VALUES('会务电脑', 0, GETDATE(), 1)
INSERT Items(Name, Status, CreatedOn, CreatedBy) VALUES('单反相机', 0, GETDATE(), 1)
INSERT Items(Name, Status, CreatedOn, CreatedBy) VALUES('投影仪', 0, GETDATE(), 1)
INSERT Items(Name, Status, CreatedOn, CreatedBy) VALUES('插座', 0, GETDATE(), 1)

INSERT ItemBorrowHistories(ItemID, StaffID, Quantity, Status, BorrowedOn) Values(1, 1, 1, 0, GETDATE())
INSERT ItemBorrowHistories(ItemID, StaffID, Quantity, Status, BorrowedOn) Values(2, 2, 1, 0, GETDATE())
INSERT ItemBorrowHistories(ItemID, StaffID, Quantity, Status, BorrowedOn) Values(3, 3, 1, 0, GETDATE())
INSERT ItemBorrowHistories(ItemID, StaffID, Quantity, Status, BorrowedOn) Values(4, 1, 5, 0, GETDATE())