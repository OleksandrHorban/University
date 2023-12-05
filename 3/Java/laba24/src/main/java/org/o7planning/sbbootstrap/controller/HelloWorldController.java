package org.o7planning.sbbootstrap.controller;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestMapping;
@Controller
public class HelloWorldController {
@RequestMapping("/")
public String helloWorld(Model model) {
return "index.html";
}
}