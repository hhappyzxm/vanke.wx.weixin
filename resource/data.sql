declare  @staffid int 

INSERT Staffs(RealName, LoginName, Password, Status, CreatedOn, CreatedBy) VALUES('刘小龙', 'lxl', 'bHhs', 0, GETDATE(), 1)
set @staffid = (SELECT @@IDENTITY)
INSERT StaffRoles(Role, StaffID, Status, CreatedOn, CreatedBy) VALUES(0, @staffid, 0, GETDATE(), 1)
INSERT StaffRoles(Role, StaffID, Status, CreatedOn, CreatedBy) VALUES(1, @staffid, 0, GETDATE(), 1)

INSERT Staffs(RealName, LoginName, Password, Status, CreatedOn, CreatedBy) VALUES('李虎', 'lh', 'bGg=', 0, GETDATE(), 1)
set @staffid = (SELECT @@IDENTITY)
INSERT StaffRoles(Role, StaffID, Status, CreatedOn, CreatedBy) VALUES(0, @staffid, 0, GETDATE(), 1)
INSERT StaffRoles(Role, StaffID, Status, CreatedOn, CreatedBy) VALUES(1, @staffid, 0, GETDATE(), 1)

INSERT Staffs(RealName, LoginName, Password, Status, CreatedOn, CreatedBy) VALUES('赵旭明', 'zxm', 'enht', 0, GETDATE(), 1)
set @staffid = (SELECT @@IDENTITY)
INSERT StaffRoles(Role, StaffID, Status, CreatedOn, CreatedBy) VALUES(0, @staffid, 0, GETDATE(), 1)
INSERT StaffRoles(Role, StaffID, Status, CreatedOn, CreatedBy) VALUES(1, @staffid, 0, GETDATE(), 1)

INSERT Items(Name, Status, CreatedOn, CreatedBy) VALUES('会务电脑', 0, GETDATE(), 1)
INSERT Items(Name, Status, CreatedOn, CreatedBy) VALUES('单反相机', 0, GETDATE(), 1)
INSERT Items(Name, Status, CreatedOn, CreatedBy) VALUES('投影仪', 0, GETDATE(), 1)
INSERT Items(Name, Status, CreatedOn, CreatedBy) VALUES('插座', 0, GETDATE(), 1)

INSERT ItemBorrowHistories(ItemID, StaffID, Quantity, Status, BorrowedOn) Values(1, 1, 1, 0, GETDATE())
INSERT ItemBorrowHistories(ItemID, StaffID, Quantity, Status, BorrowedOn) Values(2, 2, 1, 0, GETDATE())
INSERT ItemBorrowHistories(ItemID, StaffID, Quantity, Status, BorrowedOn) Values(3, 3, 1, 0, GETDATE())