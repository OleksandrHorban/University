(deffacts employees
   (employee Bandera 30 2 33000)
   (employee Shukhevich 6 0 5400)
   (employee Khmelnytskyi 13 3 4300)
   (employee Chornovil 28 4 81000)
   (employee Vunnychenko 2 1 6500)
   (employee Petlyura 25 0 90000)
)


(defrule rule1
   (employee ?lastname ?experience ?children ?salary)
   (test (or (>= ?experience 5) (>= ?children 2)))
   =>
   (assert (bonus ?lastname (* 0.2 ?salary)))
   (printout t "Rule 1 fired for " ?lastname crlf)
)

(defrule rule2
   (not (bonus ?))
   =>
   (printout t "All employees have received a bonus." crlf)
)

(defrule rule3
   (employee ?lastname ?experience&:(> ?experience 20) ?children ?salary)
   =>
   (printout t ?lastname " is a work veteran." crlf)
)

