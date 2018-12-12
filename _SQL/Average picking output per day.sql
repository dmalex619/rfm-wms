-- Средние отгрузки из зон пикинга товара ИНКО
select G.Alias, P.InBox, sum(OG.QntConfirmed / P.InBox / P.BoxInPal / 26) as Pallets
from TrafficsGoods OG with (nolock) 
inner join Packings P with (nolock) on OG.PackingID = P.ID 
inner join Goods G with (nolock) on P.GoodID = G.ID 
where OG.DateConfirm between '20090301' and '20090331' and left(G.ERPCode, 2) <> 'TM'
group by G.Alias, P.InBox
order by 3 desc

