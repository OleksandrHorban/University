(deftemplate testimony
    (slot person)
    (slot if-not-stolen-by)
    (slot stolen-by)
)

(deffacts initial-testimonies
    (testimony (person Ivan) (if-not-stolen-by Vasil) (stolen-by Petro))
    (testimony (person Petro) (if-not-stolen-by Ivan) (stolen-by Vasil))
    (testimony (person Mykola) (if-not-stolen-by Vasil) (stolen-by Ivan))
    (testimony (person Vasil) (if-not-stolen-by Petro) (stolen-by Vasil))
)

(defrule find-culprit
    (testimony (person ?accused) (if-not-stolen-by ?innocent) (stolen-by ?liar))
    (testimony (person ?liar) (if-not-stolen-by ?accused) (stolen-by ?innocent))
    (testimony (person ?third) (if-not-stolen-by ?innocent) (stolen-by ?accused))
    (testimony (person ?innocent) (if-not-stolen-by ?guilty) (stolen-by ?innocent))
    =>
    (printout t "The culprit is: " ?guilty crlf)
)

(defrule check-ivan-n-mykola
    (testimony (person Ivan) (if-not-stolen-by ?x) (stolen-by ?y))
    (testimony (person Mykola) (if-not-stolen-by ?x) (stolen-by ?z))
    =>
    (if (eq ?y ?z)
        then (printout t "Ivan and Mykola are telling the truth." crlf)
        else (printout t "Ivan and Mykola are not telling the truth." crlf)
    )
)

(defrule start
    =>
    (run)
)