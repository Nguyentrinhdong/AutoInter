(declare-datatypes () ((Type idle  curent_position  rout_to_destination))) 
(declare-const display Type) 
(declare-const usage Int) 
(declare-const legaldestination Int) 
(define-fun pPrime_p ( ) Bool 
 (if ( => ( = usage 1 ) true  ) 
 true 
 false
 ))
(define-fun R_RPrime ( ) Bool 
 (if ( => ( = display idle ) ( = display idle )  ) 
 true 
 false
 ))
(assert (=  ( and pPrime_p  R_RPrime )  true)) 
(check-sat)
