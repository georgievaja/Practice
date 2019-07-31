module Extensions
open System

    module Int64 =
        let convertToBinary (number: int64) = Convert.ToString (number, 2)    

    module Array =
        let tryMaxBy    (selector)
                        (arr: 'a[]) =
            match arr.Length = 0 with
                | false -> arr |> Array.maxBy selector |> Some
                | true -> None


    module String =
        let splitBy (separator: char) 
                    (bin: string) = bin.Split(separator, StringSplitOptions.RemoveEmptyEntries)

        let stringLength (str: string) = 
            str.Length

        let rec trimStartOf (ch: char)
                            (str: string) =
            match str.[0] = ch with
                | true  -> str.Remove(0, 1)
                            |> trimStartOf ch 
                | false -> str

        let rec trimEndOf   (ch: char)
                (str: string) =
            let lastLetter = str.Length - 1
            match str.[lastLetter] = ch with
                | true -> str.Remove(lastLetter, 1)
                            |> trimEndOf ch
                | false -> str