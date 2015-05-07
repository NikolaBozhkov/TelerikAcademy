﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NestedLists.aspx.cs" Inherits="NestedListsPage.NestedLists" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Nested Lists</title>
</head>
<body>
    <p>Preceding Text</p>
    <ol type="I">
        <li>
            &ensp;&ensp;&nbsp;List Item 1
            <ol type="a">
                <li>&ensp;Nested Item 1.1</li>
                <li>&ensp;Nested Item 1.2</li>
            </ol>
        </li>
        <li>
            &ensp;&ensp;&nbsp;List Item 2
            <ol type="1">
                <li>&ensp;Nested Item 2.1</li>
                <li>
                    &ensp;Nested Item 2.2
                    <ul type="circle">
                        <li>&emsp;Nested Item 2.2.1</li>
                        <li>
                            &emsp;Nested Item 2.2.2
                            <ul type="square">
                                <li>&emsp;&ensp;Nested Item 2.2.2.1</li>
                                <li>&emsp;&ensp;Nested Item 2.2.2.2</li>
                            </ul>
                        </li>
                        <li>&emsp;&nbsp;Nested Item 2.2.3</li>
                    </ul>
                </li>
                <li>&ensp;&nbsp;Nested Item 2.3</li>
            </ol>
        </li>
        <li>
            &emsp;&ensp;List Item 3
            <ul type="disc">
                <li>&ensp;&nbsp;Nested Item 3.1</li>
                <li>&ensp;&nbsp;Nested Item 3.2</li>
                <li>&ensp;&nbsp;Nested Item 3.3</li>
            </ul>
        </li>
    </ol>
</body>
</html>
