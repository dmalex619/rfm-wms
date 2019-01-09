select TF.CellSourceID, TF.CellTargetID, TF.FrameID, CC.Qnt 
	from TrafficsFrames TF 
	inner join CellsContents CC on TF.CellSourceID = CC.CellID and TF.FrameID = CC.FrameID 
	and CC.PackingID = 5506 and CC.GoodStateID = 1
	where DateConfirm is Null