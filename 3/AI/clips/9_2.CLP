(deffacts products
   (Tovar "Product1" 100 3 2008 "Ukraine")
   (Tovar "Product2" 150 5 2012 "China")
   (Tovar "Product3" 200 2 2015 "USA")
   (Tovar "Product4" 120 1 2005 "Germany")
   (Tovar "Product5" 180 4 2022 "Japan")
)

(defrule rule-1
   (or (and (Tovar ?name ?price ?quantity ?year "Ukraine")
            (test (< ?year 2010)))
       (and (Tovar ?name ?price ?quantity ?year ?country)
            (test (< ?quantity 4))))
   =>
   (assert (ucinka ?name (* 0.15 ?price)))
   (printout t "Rule 1: Added ucinka fact for " ?name " with a value of " (* 0.15 ?price) "." crlf)
)

(defrule rule-2
   (and (Tovar ?name ?price ?quantity ?year ?country)
        (eq ?country "Imported")
        (test (= ?year 2023)))
   =>
   (assert (nacinka ?name (* 0.07 ?price)))
   (printout t "Rule 2: Added nacinka fact for " ?name " with a value of " (* 0.07 ?price) "." crlf)
)

(defrule rule-3
   (Tovar ?name ?price ?quantity ?year "Ukraine")
   =>
   (printout t "Rule 3: Product " ?name " is of Ukrainian origin." crlf)
)

(defrule rule-3-no
   (not (Tovar ?name ?price ?quantity ?year "Ukraine"))
   =>
   (printout t "Rule 3: No Ukrainian products found in the database." crlf)
)
