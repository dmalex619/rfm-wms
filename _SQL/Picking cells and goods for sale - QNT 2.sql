drop table #Sales
SELECT DISTINCT P.Good, P.InBox 
	into #Sales
	FROM WHOutputsGoods AS I with (nolock) 
	INNER JOIN WHOutputs AS O with (nolock) ON I.WHOutput = O.Uniq
	INNER JOIN Packings P with (nolock) ON I.Packing = P.Uniq 
	WHERE   O.DateOutput >= '20070101' and 
			O.DateConfirm is not Null and 
			I.QntConfirmed > 0 and 
			O.Depot in (select Uniq from Depots where Basic = 1)

SELECT     W.Address, G.Alias, W.InBox
FROM         WHPicking AS W with (nolock) 
INNER JOIN Goods AS G with (nolock) ON W.Good = G.Uniq
WHERE     (W.Good IS NOT NULL) AND (W.Address IS NOT NULL) AND 
(str(W.Good) + '_' + str(W.InBox, 15, 3) NOT IN
(SELECT str(Good) + '_' + str(InBox, 15, 3)	FROM #Sales))
ORDER BY W.Address