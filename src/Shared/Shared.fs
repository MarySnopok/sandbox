namespace Shared

open System

type Todo = { Id: Guid; Description: string }

module Todo =
    let isValid (description: string) =
        String.IsNullOrWhiteSpace description |> not

    let create (description: string) =
        { Id = Guid.NewGuid()
          Description = description }

module Route =
    let builder typeName methodName =
        sprintf "/api/%s/%s" typeName methodName

type ITodosApi =
    { getTodos: unit -> Async<Todo list>
      addTodo: Todo -> Async<Todo> }

//addied type and module to disable "add name" buttom with name input is empty
type containerTwoValue = { Id: Guid; Description: string }

module containerTwoValue =
    let isValid (description: string) =
        String.IsNullOrWhiteSpace description |> not
