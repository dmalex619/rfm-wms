update Goods set HostID = 2 where GoodBrandID = 242 -- charindex('TM', ERPCode) > 0
update Goods set HostID = 1 where GoodBrandID <> 242 -- charindex('TM', ERPCode) = 0

update GoodsGroups set HostID = 2 where charindex('TM', ERPCode) > 0
update GoodsGroups set HostID = 1 where charindex('TM', ERPCode) = 0

update GoodsBrands set HostID = 2 where charindex('TM', ERPCode) > 0
update GoodsBrands set HostID = 1 where charindex('TM', ERPCode) = 0

update Partners set HostID = 2 where charindex('TM', ERPCode) > 0
update Partners set HostID = 1 where charindex('TM', ERPCode) = 0



update Outputs set HostID = 2 where OwnerID = 18259
update Outputs set HostID = 1 where OwnerID <> 18259

update Inputs set HostID = 2 where OwnerID = 18259
update Inputs set HostID = 1 where OwnerID <> 18259

update AuditActs set HostID = 2 where OwnerID = 18259
update AuditActs set HostID = 1 where OwnerID <> 18259
