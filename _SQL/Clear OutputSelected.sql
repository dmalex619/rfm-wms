update OutputsGoods set QntSelected = 0
update Outputs set DateSelect = Null

delete TrafficsGoods
delete TrafficsFrames where DateConfirm is Null
update Frames set HasTraffic = 0, State = 'S' where HasTraffic = 1
