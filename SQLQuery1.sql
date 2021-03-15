﻿select o.ORDERID orderNumber,
o.ORDERDATE orderDate,
'' as deliveryAddress,
o.DELIVERYEXPECTED deliveryExpected,
case when o.CONTAINSGIFT = 0 THEN p.PRODUCTNAME 
else 'Gift'
end product,
ot.QUANTITY quantity,
ot.PRICE priceEach
from ORDERS o
join OrderItems ot
on o.ORDERID = ot.ORDERID
join PRODUCTS p
on p.PRODUCTID = ot.PRODUCTID
where o.CUSTOMERID = 'C34454'
and o.ORDERID = (select MAX(ORDERID) from ORDERS o1 where o.CUSTOMERID = o1.CUSTOMERID)



