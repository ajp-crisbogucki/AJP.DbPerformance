## AJP Performance DB

#### Results :

    -------------------------------------------------------------------------------------
    -| TEST NAME                             | Count Exec    | Time in ms    | Count  
    -------------------------------------------------------------------------------------
    -| Insert one by one single connection   | 43784         | 95485ms       | 919464
    -------------------------------------------------------------------------------------
    -| Insert one by one common connection   | 43784         | 94430ms       | 963248
    -------------------------------------------------------------------------------------
    -| Insert one range - one connection     | 43784         | 403ms         | 1007032
    -------------------------------------------------------------------------------------
    -| Insert one by one by Entity Framework | 43784         | 223339ms      | 1097647 
    -------------------------------------------------------------------------------------
    -| Insert one package by Entity Framework| 43784         | 7814ms        | 1141431  
    -------------------------------------------------------------------------------------
    -| Insert package size 1000 row by EF    | 43784         | 8483ms        | 1185215   

