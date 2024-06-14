# Nat

This is the dotnet implementation of the answer to one of the questions on a test in the "PL - Programming Languages" class that I took during college.

> Thought Exercise: representation of a non-negative integer

### Original question (in Brazilian Portuguese)

Vimos, na última prova, que o tipo primitivo `int` não é necessário em ML.
Acontece que este tipo também não é necessário em Java.
Considere a seguinte interface, que representa inteiros não-negativos:
```
interface Nat {
    Nat plus (Nat n);
    boolean isZero();
    void loop(CodeBlock b);
}

interface CodeBlock {
    void execute();
}
```

O método `plus` retorna a soma do valor representado pelo receptor com um outro número, passado como argumento. Esse métoddo não muda nem o receptor, nem o argumento.
O método `isZero` determina se o receptor é o número zero.
O métoddo `loop` implementa um tipo simples de laço `for`: o corpo do laço representado pela interface `CodeBlock`, deve ser executado `n` vezes, onde `n` é o valor representado pelo objeto receptor.

Defina as classes `Zero` and `Succ`, cada uma delas implementando a interface `Nat`.
`Zero` representará o número zero, e `Succ` representará o sucessor imediato de um número, recursivamente.
Estas classes serão usadas para representar números em base unária.
Por exemplo, o número dois seria representado pelo seguinte objeto: `new Succ(new Succ(new Zero()))`.
Assim, `Zero` deve ter o construtor parão sem argumentos (que não faz nada), e `Succ` deve ter um construtor que recebe um argumento do tipo `Nat`, representando o inteiro que será sucedido.
Este argumento deve ser mantido em um campo privado, para usos posteriores.
Veja, por exemplo, o trecho de código abaixo:
```
Nat n1 = new Succ(new Zero());
Nat n2 = new Succ(new Succ(new Zero()));
Nat n3 = n1.plus(n2);

class CB implements CodeBlock() {
    void execute() { System.out.println("Oi!"); }
}

n3.loop(new CB());
```

Esse programa irá imprimir `Oi!` três vezes na saída padrão.

Sua solução não poderá usar os inteiros primitivos de Java, nem qualquer outro tipo primitivo numérico como `float` ou `double`.
Também não é permitido o uso da primitiva `instanceof`
