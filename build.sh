#!/bin/bash
# Compila todos os projetos, exceto Prosoft.Company.WF
for project in $(find . -name '*.csproj' | grep -v 'Prosoft.Company.WF'); do
    dotnet build "$project"
done
