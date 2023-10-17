package org.o7planning.sbgroovy.controller;

import java.util.ArrayList;
import java.util.List;

import org.o7planning.sbgroovy.model.Person;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestMapping;

@Controller
public class MainController {

    private static List<Person> persons = new ArrayList<Person>();

    static {
        persons.add(new Person("Bill", "Gates"));
        persons.add(new Person("Steve", "Jobs"));
    }

    @RequestMapping(value = "/")
    public String handleRequest(Model model) {
        
        String message = "Person List:";
        
        model.addAttribute("message", message);
        model.addAttribute("persons", persons);

        return "index";
    }

}
