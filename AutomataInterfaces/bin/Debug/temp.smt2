(declare-datatypes () ((GoodsKind null  Beer  Drink CashType Money))) 
(declare-const Selectgoods GoodsKind) 
(declare-const DeliverGoods GoodsKind) 
(define-fun pPrime_p ( ) Bool 
 (if ( => true true  ) 
 true 
 false
 ))
(define-fun R_RPrime ( ) Bool 
 (if ( => ( and ( = Money 0 ) ( = Selectgoods null ) ) ( and ( = Money 0 ) ( = Selectgoods null ) )  ) 
 true 
 false
 ))
(assert (=  ( and pPrime_p  R_RPrime )  true)) 
(check-sat)
