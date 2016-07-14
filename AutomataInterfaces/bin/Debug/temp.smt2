(declare-datatypes () ((Type idle  current_position  route_to_destination))) 
(declare-const display Type) 
(declare-const usage Int) 
(declare-const legaldestination Bool) 
(define-fun F ( ) Bool 
 (if ( and ( not ( = usage 0 ) ) ( and ( and ( and ( = legaldestination true ) ( = usage 0 ) ) ( = display route_to_destination ) ) ( = usage 0 ) ) )   
 true 
 false
 ))
(assert (= F  true)) 
(check-sat) 
 
