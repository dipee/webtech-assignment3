#!/bin/bash

if [ -z "$1" ]
then
    echo "No migration name supplied"
else
    dotnet ef migrations add $1 --output-dir Data/Migrations
    dotnet ef database update
fi