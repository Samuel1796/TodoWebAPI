using Microsoft.AspNetCore.Mvc;
using TodoAPI.DTOs;
using TodoAPI.Models;

namespace TodoAPI.Controllers;
[ApiController]
[Route("api/todos")]

public class TodoController : ControllerBase
{

    private static List<Todo> _todolist = new List<Todo>();


    // Endpoint to create a new todo
    [HttpPost("CreateTodo")]
    public IActionResult CreateTodo(TodoRequestDTO requestDTO)
    {
        var todo = new Todo
        {
            Title = requestDTO.Title,
            Description = requestDTO.Description,

        };
        _todolist.Add(todo);
        return Ok(todo);
    }

    //ENDPOINT TO GET ALL TODOS
    [HttpGet("allTodos")]
    public IActionResult GetTodos()
    {
        return Ok(_todolist);
    }


    //ENDPOINT TO GET A TODO BY ID
    [HttpGet("{id}")]
    public IActionResult GetTodoById(Guid id)
    {
        var targetTodo = _todolist.FirstOrDefault(t => t.Id == id);
        if (targetTodo == null) {
            return NotFound();
        }
        else
        {
            return Ok(targetTodo);
        }
    }

    //ENDPOINT TO UPDATE A TODO
    [HttpPut("update/{id}")]

    public IActionResult UpdateTodo(Guid id, TodoRequestDTO requestDTO)
    {
        var targetTodo = _todolist.FirstOrDefault(t => t.Id == id);
        if (targetTodo != null)
        {
            targetTodo.Title = requestDTO.Title;
            targetTodo.Description = requestDTO.Description;

            return Ok(targetTodo);

        }
        else
        {
            return NotFound(id);
        }
    }

    // ENDPOINT TO DELETE ALL TODOS
    [HttpDelete("deleteAll")]
    public IActionResult DeleteAllTodo() { 
        _todolist.Clear();
        return Ok("All Todos deleted");

    }

    //ENPOINT TOT DELETE A TOD BY ID
    [HttpDelete("delete/{id}")]

    public IActionResult DeleteTodoById(Guid id)
    {
        var targetTodo = _todolist.FirstOrDefault(t => t.Id == id);
        if (targetTodo != null)
        {
            _todolist.Remove(targetTodo);
            return Ok($"Todo with ID {id} deleted");
        }
        else
        {
            return NotFound(id);
        }
    }
}

//LEARN LINQ