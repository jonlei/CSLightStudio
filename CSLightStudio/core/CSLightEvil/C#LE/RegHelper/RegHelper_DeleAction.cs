﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CSLE
{



    public class RegHelper_DeleAction : RegHelper_Type ,ICLS_Type_Dele
    {

        public RegHelper_DeleAction( string setkeyword)
            : base(typeof(Action), setkeyword)
        {

        }


        public override object Math2Value(CLS_Content env, char code, object left, CLS_Content.Value right, out CLType returntype)
        {
            returntype = null;

            if (left is DeleObject && right.value is DeleObject)
            {
                DeleObject info = left as DeleObject;
                DeleObject calldele = right.value as DeleObject;
                if (code == '+')
                    info._event.AddEventHandler(info.source, calldele.deleInstance);
                else if (code == '-')
                    info._event.AddEventHandler(info.source, calldele.deleInstance);


            }

            return null;
        }
        public override object DefValue
        {
            get
            {
                return new DeleObject(null);

            }
        }


        public string GetParamSign(ICLS_Environment env)
        {
            return "";
        }

        public Delegate CreateDelegate(ICLS_Environment env, SType calltype, SInstance callthis, string function)
        {

            Action dele = () =>
            {
              
                CLS_Content content = new CLS_Content(env);
                content.CallThis = callthis;
                content.CallType = calltype;
                content.function = function;
                var func = calltype.functions[function];

                //content.DefineAndSet(function._paramnames[0], function._paramtypes[0].type, param0);

                func.expr_runtime.ComputeValue(content);
            };
            return dele;
        }
    }
}
