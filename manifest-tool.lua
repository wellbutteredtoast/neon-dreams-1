-- NeonDreams Manifest Tool
--
-- -maj >> major version
-- -min >> minor version
-- -ptc >> patch version
-- -stg >> stage identifier

function write_to_file(major, minor, patch, stage_id)
    local output = "manifest.json"
    local manifest_str = string.format([[
{
    "manifest": {
        "version": [ %s, %s, %s ],
        "build_date": "%s",
        "stage": "%s"
    }
}

]], major, minor, patch, os.date("!%Y-%m-%d@%H:%M:%S"), stage_id)

    local file = io.open(output, "w")
    if file then
        file:write(manifest_str)
        file:close()
    else
        print("Failed to open " .. output .. "!")
    end
end

function main()
    local maj, min, ptc, stg = nil, nil, nil, nil

    for i, v in ipairs(arg) do
        v = v:lower()

        if v == "-maj" then
            maj = arg[i + 1]
        elseif v == "-min" then
            min = arg[i + 1]
        elseif v == "-ptc" then
            ptc = arg[i + 1]
        elseif v == "-stg" then
            stg = arg[i + 1]
        end
    end

    if not (maj and min and ptc and stg) then
        print("Usage: lua script.lua -maj X -min Y -ptc Z -stg STAGE")
        os.exit(1)
    end

    write_to_file(maj, min, ptc, stg)
end

main()