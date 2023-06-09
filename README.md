# Chess Online

Fully written chess online game written in *C#*.

### Login
To start the game, you needs to log in first with **username** and **password**, otherwise error will appear.

### Registration
If you don't have account yet, you can create one by clicking on **Register** and filling all required informations.

### Start Game
After you are logged, you can choose from two opůtions:
```
1. Host
2. Client
```

If you choose host, you will be redirected to game screen and wait for opponent to join.
If you choose client, you needs to fill IP of host (or leave it black if you wants to play on *localhost*). 
Than you will be redirected to game screen and joined to host, if host already started the game.

### Game Over
If any player discard opponents **King** piece, the game will end, both players will be informed about the winner. Than the program will close itself.

---------------------------------------------------------------------------------------------------------------

### Error Handling
Program is reacts to every input with reasonable way and should not crash

#### Run Program
To run the program, you can go to "/bin/Debug/Chess.exe".

##### Missing functions
Program is still missing some chess functions (due to lack of time). These are:
```
1. Stalemate
2. En peassant
3. Castling
```