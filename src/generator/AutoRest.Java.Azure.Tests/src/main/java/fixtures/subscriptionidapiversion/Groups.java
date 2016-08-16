/**
 * Copyright (c) Microsoft Corporation. All rights reserved.
 * Licensed under the MIT License. See License.txt in the project root for
 * license information.
 *
 * Code generated by Microsoft (R) AutoRest Code Generator.
 * Changes may cause incorrect behavior and will be lost if the code is
 * regenerated.
 */

package fixtures.subscriptionidapiversion;

import com.microsoft.rest.ServiceCall;
import com.microsoft.rest.ServiceCallback;
import com.microsoft.rest.ServiceResponse;
import fixtures.subscriptionidapiversion.models.ErrorException;
import fixtures.subscriptionidapiversion.models.SampleResourceGroup;
import java.io.IOException;

/**
 * An instance of this class provides access to all the operations defined
 * in Groups.
 */
public interface Groups {
    /**
     * Provides a resouce group with name 'testgroup101' and location 'West US'.
     *
     * @param resourceGroupName Resource Group name 'testgroup101'.
     * @throws ErrorException exception thrown from REST call
     * @throws IOException exception thrown from serialization/deserialization
     * @throws IllegalArgumentException exception thrown from invalid parameters
     * @return the SampleResourceGroup object wrapped in {@link ServiceResponse} if successful.
     */
    ServiceResponse<SampleResourceGroup> getSampleResourceGroup(String resourceGroupName) throws ErrorException, IOException, IllegalArgumentException;

    /**
     * Provides a resouce group with name 'testgroup101' and location 'West US'.
     *
     * @param resourceGroupName Resource Group name 'testgroup101'.
     * @param serviceCallback the async ServiceCallback to handle successful and failed responses.
     * @throws IllegalArgumentException thrown if callback is null
     * @return the {@link ServiceCall} object
     */
    ServiceCall<SampleResourceGroup> getSampleResourceGroupAsync(String resourceGroupName, final ServiceCallback<SampleResourceGroup> serviceCallback) throws IllegalArgumentException;

}
